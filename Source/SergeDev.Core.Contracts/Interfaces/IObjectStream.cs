using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Contracts.Interfaces
{
  public interface IObjectStream<T>
  {
    bool HasObject();

    T Peek();

    T Take();
  }
}
