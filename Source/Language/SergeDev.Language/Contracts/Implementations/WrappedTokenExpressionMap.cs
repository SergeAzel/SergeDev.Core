using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Core.Extension;

namespace SergeDev.Language.Core.Implementations
{
  public class WrappedTokenExpressionMap<T, B> : BaseTokenExpressionMap<B> where T : class, B where B : class
  {
    private ITokenExpressionMap<T> wrapped;
    public WrappedTokenExpressionMap(ITokenExpressionMap<T> wrapped)
    {
      this.wrapped = wrapped;
    }

    public override IReadExpression<B> Map(IToken source)
    {
      return wrapped.Map(source).Wrap<T, B>();
    }
  }
}
