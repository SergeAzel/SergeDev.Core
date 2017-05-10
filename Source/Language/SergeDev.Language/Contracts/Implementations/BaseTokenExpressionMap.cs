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
  public abstract class BaseTokenExpressionMap<T> : ITokenExpressionMap<T> where T : class
  {
    public abstract IReadExpression<T> Map(IToken source);

    IReadExpression<T> IMap<IToken, IReadExpression<T>>.Map(IToken source, IReadExpression<T> otherwise)
    {
      IReadExpression<T> value = otherwise;
      Map(source).Use(r => value = r);
      return value;
    }
  }
}
