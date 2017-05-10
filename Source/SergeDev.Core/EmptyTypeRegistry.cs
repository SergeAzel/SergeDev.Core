using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public class EmptyTypeRegistry : IReadOnlyTypeRegistry
  {
    public T Instance<T>() where T : class
    {
      return default(T);
    }

    public bool IsRegistered<T>() where T : class
    {
      return false;
    }
  }
}
