using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Contracts.Interfaces
{
  public interface ITypeDictionary : ICloneable<ITypeDictionary>
  {
    void Clear();

    bool Contains<T>();

    bool Contains(Type type);

    T Get<T>();

    object Get(Type type);

    bool Remove<T>();

    bool Remove(Type type);

    void Set<T>(T value);

    void Set(Type type, object value);

    IEnumerable<Type> GetTypes();
  }
}
