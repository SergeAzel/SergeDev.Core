using SergeDev.Contracts.Interfaces;
using SergeDev.Core.Extension;
using SergeDev.Language.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Extensions
{
  public static class LexorMatchBuilderExtensions
  {
    public static MatchBuilder<S, T> InitialMatch<S, T>(this MatchBuilder<S, T> me, IEnumerable<S> match)
    {
      return me.InitialTransform(ios => TakeCompareToEnumerable<S>(ios, match));
    }

    public static MatchBuilder<S, T> InitialMatch<S, T>(this MatchBuilder<S, T> me, S match)
    {
      return me.InitialMatch(match.Yield());
    }

    public static MatchBuilder<S, T> UntilMatch<S, T>(this MatchBuilder<S, T> me, IEnumerable<S> match, bool consumeMatch)
    {
      return me.UntilTransform(ios => YieldUntilMatch<S>(ios, match, consumeMatch));
    }

    public static MatchBuilder<S, T> UntilMatch<S, T>(this MatchBuilder<S, T> me, S match, bool consumeMatch)
    {
      return me.UntilMatch(match.Yield(), consumeMatch);
    }

    public static MatchBuilder<S, T> UntilComparison<S, T>(this MatchBuilder<S, T> me, Func<S, bool> comparison)
    {
      return me.UntilTransform(ios => YieldUntilComparison<S>(ios, comparison));
    }

    private static IEnumerable<S> YieldUntilComparison<S>(IObjectStream<S> source, Func<S, bool> comparison)
    {
      while (!comparison(source.Peek()))
      {
        yield return source.Take();
      }
    }

    private static IEnumerable<S> YieldUntilMatch<S>(IObjectStream<S> source, IEnumerable<S> match, bool consume)
    {
      var count = PeekCompareToEnumerable<S>(source, match);
      while (count <= 0)
      {
        yield return source.Take();
        count = PeekCompareToEnumerable<S>(source, match);
      }

      if (consume)
        foreach (var item in source.Take(count))
          yield return item;
    }

    private static IEnumerable<S> TakeCompareToEnumerable<S>(IObjectStream<S> source, IEnumerable<S> match)
    {
      return source.Take(PeekCompareToEnumerable(source, match));
    }

    private static bool CompareToEnumerable<S>(IObjectStream<S> source, IEnumerable<S> match)
    {
      return PeekCompareToEnumerable(source, match) > 0;
    }

    private static int PeekCompareToEnumerable<S>(IObjectStream<S> source, IEnumerable<S> match)
    {
      var comparer = EqualityComparer<S>.Default;

      var i = 0;
      foreach (var item in match)
      {
        if (!comparer.Equals(item, source.Peek(i)))
          return 0;

        ++i;
      }
      return i;
    }
  }
}
