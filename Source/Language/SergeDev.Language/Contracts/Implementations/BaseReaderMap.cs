using SergeDev.Core.Extension;
using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Language.Core.Implementations
{
  public abstract class BaseReaderMap<S, T> : IReaderMap<S, T> where T : class
  {
    public abstract IReadPartial<S, T> Map(S source);

    public IReadPartial<S, T> Map(S source, IReadPartial<S, T> otherwise)
    {
      IReadPartial<S, T> value = otherwise;
      Map(source).Use(r => value = r);
      return value;
    }
  }
}
