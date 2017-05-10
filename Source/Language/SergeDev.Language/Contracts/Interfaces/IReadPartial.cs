using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Language.Core.Interfaces
{
  public interface IReadPartial<S, T>
  {
    T Read(IObjectStream<S> source);
  }
}
