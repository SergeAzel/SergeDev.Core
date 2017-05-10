using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Language.Core.Implementations
{
  public class WrappedReadPartial<S, T, B> : IReadPartial<S, B> where T : class, B where B : class
  {
    private IReadPartial<S, T> wrapped;
    public WrappedReadPartial(IReadPartial<S, T> wrapped)
    {
      this.wrapped = wrapped;
    }

    public B Read(IObjectStream<S> source)
    {
      return wrapped.Read(source);
    }
  }
}
