using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Contracts.Interfaces
{
  public interface ITypeRegistry : IReadOnlyTypeRegistry
  {
    /// <summary>
    /// Registers an instance of type T.  If T is already registered, registers the new instance over the existing instance.
    /// Passing in null is equivalent to calling Unregister.
    /// </summary>
    void Register<T>(T instance) where T : class;

    /// <summary>
    /// Removes registration for type T.  After calling this method, the Instance method should return null for this type.
    /// </summary>
    void Unregister<T>() where T : class;
  }
}
