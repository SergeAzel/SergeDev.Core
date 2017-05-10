using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Core
{
  public class TypeRegistry : ITypeRegistry
  {
    private ITypeDictionary typeDictionary;

    public TypeRegistry()
    {
      this.typeDictionary = new TypeDictionary();
    }

    public T Instance<T>() where T : class 
    {
      T instance = default(T);
      if (typeDictionary.Contains<T>())
      {
        instance = typeDictionary.Get<T>();
      }
      return instance;
    }

    public bool IsRegistered<T>() where T : class
    {
      return typeDictionary.Contains<T>();
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

    public void Unregister<T>() where T : class
    {
      typeDictionary.Remove<T>();
    }
  }
}
