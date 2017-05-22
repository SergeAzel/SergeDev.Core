using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;
using System.Text.RegularExpressions;

namespace SergeDev.Language.Core.Implementations
{
  public class TakeWhile<S, T> : IReadPartial<S, T>
  {
    private Func<S, bool> condition;
    private Func<IEnumerable<S>, T> tokenize;

    public TakeWhile(Func<S, bool> condition, Func<IEnumerable<S>, T> tokenize)
    {
      this.condition = condition;
      this.tokenize = tokenize;
    }

    public T Read(IObjectStream<S> source)
    {
      return tokenize(Yield(source));
    }

    private IEnumerable<S> Yield(IObjectStream<S> source)
    {
      while (condition(source.Peek()))
      {
        yield return source.Take();
      }
    }
  }
}
