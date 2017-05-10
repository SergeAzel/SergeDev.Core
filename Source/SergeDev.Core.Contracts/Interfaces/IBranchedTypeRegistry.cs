using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Contracts.Interfaces
{
  public interface IBranchedTypeRegistry : ITypeRegistry
  {
    /// <summary>
    /// Returns true if this instance has local behavior for type T.
    /// If type T would be derived from the parent instance, returns false.
    /// </summary>
    bool IsOverridden<T>() where T : class;

    /// <summary>
    /// Removes local behavior for type T
    /// </summary>
    void Reinherit<T>() where T : class;
  }
}
