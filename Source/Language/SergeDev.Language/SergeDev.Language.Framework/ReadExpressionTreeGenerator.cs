using SergeDev.Contracts.Interfaces;
using SergeDev.Core;
using SergeDev.Core.Extension;
using SergeDev.Language.Core.Extension;
using SergeDev.Language.Core.Implementations;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Syntax.Expressions;
using SergeDev.Language.Syntax.Interfaces;
using SergeDev.Language.Syntax.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Framework
{
  /// <summary>
  /// Built to create a tree of token generators.  Currently mandate that it is a class.
  /// Find a way to make generic later?
  /// </summary>
  public class ReadExpressionTreeGenerator<S, R>
  {
    private ITypeDictionary typeDictionary;
    public ReadExpressionTreeGenerator()
    {
      if (typeof(R).IsInterface)
        throw new Exception("Cannot initialize ReadExpressionTreeGenerator with an interface.");

      typeDictionary = new TypeDictionary();
    }

    public void Add<T>(IReaderMap<S, T> instance) where T : class, R
    {
      var map = typeDictionary.Get<IReaderMap<S, T>>();
      if (map != null)
      {
        if(!(map as ReaderMapCollection<S, T>).Use(c =>
        {
          if (!(instance as ReaderMapCollection<S, T>).Use(i =>
          {
            foreach (var internalMap in i.Collection)
            {
              c.Add(internalMap);
            }
          }))
          {
            throw new Exception("Cannot register a ReaderMapCollection that is used as a base class to another registered ReaderMapCollection.");
          }
        }))
        {
          throw new Exception("Cannot register a ReaderMapCollection that is used as a base class to another registered ReaderMapCollection.");
        }
      }
      else
      {
        typeDictionary.Set<IReaderMap<S, T>>(instance);

        if (typeof(T) != typeof(R))
          AddParentCollectionReflected<T>(instance);
      }
    }

    //Private method to recurse through parent types of the previously added instance.  
    //Requires reflection, ugh.  Dirty, but it will do the trick.  At least we can keep it constrained to this method.
    private void AddParentCollectionReflected<T>(IReaderMap<S, T> instance)
    {
      var collection = typeof(ReaderMapCollection<,>).MakeGenericType(typeof(S), typeof(T).BaseType).GetConstructor(new Type[] { }).Invoke(new object[] { });

      this.GetType().GetMethod("AddParentCollectionGeneric").MakeGenericMethod(typeof(T), typeof(T).BaseType).Invoke(this, new object[] { collection, instance });
    }

    private void AddParentCollectionGeneric<T, B>(ReaderMapCollection<S, B> collection, IReaderMap<S, T> instance) where T : class, B where B : class, R
    {
      collection.Add(instance.Wrap<S, T, B>());

      Add(collection);
    }
  }
}
