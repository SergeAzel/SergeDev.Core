using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Core.Implementations
{
  public class Match<S, T> : IReadPartial<S, T>
  {
    private IEnumerable<S> match;
    private Func<IEnumerable<S>, T> tokenize;
    private IReadPartial<S, T> followed;

    public Match(IEnumerable<S> match, Func<IEnumerable<S>, T> tokenize, Func<IEnumerable<S>, T> until, IReadPartial<S, T> followed)
    {

    }

    public IEnumerable<T> Read(Contracts.Interfaces.IObjectStream<S> source)
    {

    }
  }
}
