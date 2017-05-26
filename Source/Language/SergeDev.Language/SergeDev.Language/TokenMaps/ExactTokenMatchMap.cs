using SergeDev.Language.Core.Implementations;
using SergeDev.Language.Syntax.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Core;
using SergeDev.Core.Extension;
using System.Globalization;

namespace SergeDev.Language.Syntax.TokenMaps
{
  public class ExactTokenMatchMap : BaseReaderMap<char, IToken>
  {
    private Dictionary<string, IReadPartial<char, IToken>> matches;
    private CachedExpression<IEnumerable<KeyValuePair<string, IReadPartial<char, IToken>>>> sortedMatches;
    private IReadPartial<char, IToken> otherwise;

    public ExactTokenMatchMap(IReadPartial<char, IToken> otherwise = null)
    {
      matches = new Dictionary<string, IReadPartial<char, IToken>>();
      sortedMatches = new CachedExpression<IEnumerable<KeyValuePair<string, IReadPartial<char, IToken>>>>(() =>
      {
        return matches.AsEnumerable().OrderByDescending(kvp => kvp.Key.Length).ToList();
      });

      this.otherwise = otherwise;
    }

    public bool Add(BaseExactTokenMatch matchReader)
    {
      return Add(matchReader.Match, matchReader);
    }

    public bool Add(string match, IReadPartial<char, IToken> map)
    {
      if (!matches.ContainsKey(match) && match.Length > 0)
      {
        matches.Add(match, map);
        sortedMatches.Expire();
        return true;
      }
      return false;
    }

    public override IReadPartial<char, IToken> Map(IReadOnlyObjectStream<char> source)
    {
      var sortedMatchesResult = sortedMatches.Evaluate();

      if (sortedMatchesResult.Any())
      {
        var maxLength = sortedMatchesResult.First().Key.Length;
        var fullPreview = new string(source.PeekMany(maxLength).ToArray());

        foreach (var kvp in sortedMatchesResult)
        {
          if (fullPreview.Length >= kvp.Key.Length && fullPreview.StartsWith(kvp.Key, StringComparison.Ordinal))
          {
            return kvp.Value;
          }
        }
      }
      return otherwise;
    }
  }
}
