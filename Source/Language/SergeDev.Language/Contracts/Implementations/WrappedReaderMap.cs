using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Core.Extension;

namespace SergeDev.Language.Core.Implementations
{
  public class WrappedReaderMap<S, T, B> : BaseReaderMap<S, B> where T : class, B where B : class
  {
    private IReaderMap<S, T> wrapped;
    public WrappedReaderMap(IReaderMap<S, T> wrapped)
    {
      this.wrapped = wrapped;
    }

    public override IReadPartial<S, B> Map(S source)
    {
      return wrapped.Map(source).Wrap<S, T, B>();
    }
  }
}
