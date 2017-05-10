using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Language.Core.Implementations
{
  public class WrappedReadExpression<T, B> : IReadExpression<B> where T : class, B where B : class
  {
    private IReadExpression<T> wrapped;
    public WrappedReadExpression(IReadExpression<T> wrapped)
    {
      this.wrapped = wrapped;
    }

    public B Read(IObjectStream<IToken> source)
    {
      return wrapped.Read(source);
    }
  }
}
