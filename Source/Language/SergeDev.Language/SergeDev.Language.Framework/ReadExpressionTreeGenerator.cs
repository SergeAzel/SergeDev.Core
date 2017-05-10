using SergeDev.Contracts.Interfaces;
using SergeDev.Core;
using SergeDev.Core.Extension;
using SergeDev.Language.Core.Extension;
using SergeDev.Language.Contracts.Implementations;
using SergeDev.Language.Core.Interfaces;
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
  public class ReadExpressionTreeGenerator<R> where R : class
  {
    private ITypeDictionary typeDictionary;
    public ReadExpressionTreeGenerator()
    {
      if (typeof(R).IsInterface)
        throw new Exception("Cannot initialize ReadExpressionTreeGenerator with an interface.");

      typeDictionary = new TypeDictionary();
    }

    public void Add<T>(ITokenExpressionMap<T> instance) where T : class, R
    {
      var map = typeDictionary.Get<ITokenExpressionMap<T>>();
      if (map != null)
      {
        if(!(map as TokenExpressionMapCollection<T>).Use(c =>
        {
          if (!(instance as TokenExpressionMapCollection<T>).Use(i =>
          {
            foreach (var internalMap in i.Collection)
            {
              c.Add(internalMap);
            }
          }))
          {
            throw new Exception("Cannot register a TokenExpressionMap that is used as a base class to another registered TokenExpressionMap.");
          }
        }))
        {
          throw new Exception("Cannot register a TokenExpressionMap that is used as a base class to another registered TokenExpressionMap.");
        }
      }
      else
      {
        typeDictionary.Set<ITokenExpressionMap<T>>(instance);

        if (typeof(T) != typeof(R))
          AddParentCollectionReflected<T>(instance);
      }
    }

    //Private method to recurse through parent types of the previously added instance.  
    //Requires reflection, ugh.  Dirty, but it will do the trick.  At least we can keep it constrained to this method.
    private void AddParentCollectionReflected<T>(ITokenExpressionMap<T> instance)
    {
      var collection = typeof(TokenExpressionMapCollection<>).MakeGenericType(typeof(T).BaseType).GetConstructor(new Type[] { }).Invoke(new object[] { });

      this.GetType().GetMethod("AddParentCollectionGeneric").MakeGenericMethod(typeof(T), typeof(T).BaseType).Invoke(this, new object[] { collection, instance });
    }

    private void AddParentCollectionGeneric<T, B>(TokenExpressionMapCollection<B> collection, ITokenExpressionMap<T> instance) where T : class, B where B : class, R
    {
      collection.Add(instance.Wrap<T, B>());

      Add(collection);
    }
  }
}
