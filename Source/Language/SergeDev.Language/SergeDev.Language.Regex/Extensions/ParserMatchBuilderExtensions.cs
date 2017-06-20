using SergeDev.Language.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Extensions
{
  public static class ParserMatchBuilderExtensions
  {
    public static MatchBuilder<S, T> MatchType<M, S, T>(this MatchBuilder<S, T> me) where M : S
    {
      return me.UntilComparison((s) => !(s is M));
    }
  }
}
