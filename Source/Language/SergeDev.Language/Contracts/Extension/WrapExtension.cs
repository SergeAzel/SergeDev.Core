using SergeDev.Language.Core.Implementations;
using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Core.Extension
{
  public static class WrapExtension
  {
    public static IReadExpression<B> Wrap<T, B>(this IReadExpression<T> wrapped) where T : class, B where B : class
    {
      return new WrappedReadExpression<T, B>(wrapped);
    }

    public static ITokenExpressionMap<B> Wrap<T, B>(this ITokenExpressionMap<T> wrapped) where T : class, B where B : class
    {
      return new WrappedTokenExpressionMap<T, B>(wrapped);
    }
  }
}
