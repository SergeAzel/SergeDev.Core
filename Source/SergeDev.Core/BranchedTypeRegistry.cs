using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public class BranchedTypeRegistry : IBranchedTypeRegistry
  {
    private IReadOnlyTypeRegistry parent;
    private ITypeDictionary typeDictionary;

    public BranchedTypeRegistry(IReadOnlyTypeRegistry parent)
    {
      if (parent == null)
        parent = new EmptyTypeRegistry();

      this.parent = parent;
      this.typeDictionary = new TypeDictionary();
    }

    public T Instance<T>() where T : class
    {
      T instance = default(T);
      if (typeDictionary.Contains<T>())
      {
        instance = typeDictionary.Get<T>();
      }
      else
      {
        instance = parent.Instance<T>();
      }
      return instance;
    }

    public bool IsOverridden<T>() where T : class
    {
      return typeDictionary.Contains<T>();
    }

    public bool IsRegistered<T>() where T : class
    {
      return Instance<T>() != default(T);
    }

    public void Register<T>(T instance) where T : class
    {
      if (instance != null)
      {
        typeDictionary.Set<T>(instance);
      }
      else
      {
        Unregister<T>();
      }
    }

    public void Reinherit<T>() where T : class
    {
      //Unsets the type in the local copy, so that we can re-derive the instance based on the parent.
      typeDictionary.Remove<T>();
    }

    public void Unregister<T>() where T : class
    {
      //Implementation detail - allows us to "unset" a type that a parent registry can access, but that we don't want to provide access to.
      typeDictionary.Set<T>(default(T));
    }
  }
}
