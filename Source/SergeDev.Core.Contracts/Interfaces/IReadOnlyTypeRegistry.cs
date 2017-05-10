using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Contracts.Interfaces
{
  public interface IReadOnlyTypeRegistry
  {
    /// <summary>
    /// Returns true only if Instance would return a non-null value.
    /// </summary>
    bool IsRegistered<T>() where T : class;

    /// <summary>
    /// Returns the registered instance of type T.  Returns null if none is registered.
    /// </summary>
    T Instance<T>() where T : class;
  }
}
