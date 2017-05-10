using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Contracts.Interfaces
{
  public interface IMap<S, T>
  {
    T Map(S source);

    T Map(S source, T otherwise);
  }
}
