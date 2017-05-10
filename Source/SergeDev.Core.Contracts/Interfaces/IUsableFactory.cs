using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Contracts.Interfaces
{
  public interface IUsableFactory<T> where T : IDisposable
  {
    void UseInstance(Action<T> action);
  }
}
