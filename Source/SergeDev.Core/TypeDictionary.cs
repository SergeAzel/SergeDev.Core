using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Core
{
  public class TypeDictionary : ITypeDictionary
  {
    private Dictionary<Type, object> internalDictionary;

    public TypeDictionary()
    {
      internalDictionary = new Dictionary<Type, object>();
    }

    public void Clear()
    {
      internalDictionary.Clear();
    }

    public bool Contains<T>()
    {
      return Contains(typeof(T));
    }

    public bool Contains(Type type)
    {
      return internalDictionary.ContainsKey(type);
    }

    public T Get<T>()
    {
      if (Contains<T>())
      {
        return (T) internalDictionary[typeof(T)];
      }
      else
      {
        return default(T);
      }
    }

    public object Get(Type type)
    {
      if (Contains(type))
      {
        return internalDictionary[type];
      }
      else
      {
        return null;
      }
    }

    public bool Remove<T>()
    {
      return internalDictionary.Remove(typeof(T));
    }

    public bool Remove(Type type)
    {
      return internalDictionary.Remove(type);
    }

    public void Set<T>(T value)
    {
      internalDictionary[typeof(T)] = value;
    }

    public void Set(Type type, object value)
    {
      if ((value != null && type.IsAssignableFrom(value.GetType())) 
        || (value == null && (!type.IsValueType || (Nullable.GetUnderlyingType(type) != null))))
      {
        internalDictionary[type] = value;
      }
      else
      {
        throw new InvalidCastException();
      }
    }

    public IEnumerable<Type> GetTypes()
    {
      return internalDictionary.Keys;
    }

    public ITypeDictionary Clone()
    {
      var clone = new TypeDictionary();
      foreach (var type in GetTypes())
      {
        clone.Set(type, Get(type));
      }
      return clone;
    }
  }
}
