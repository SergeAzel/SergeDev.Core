using SergeDev.Language.Core.Implementations;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Syntax.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.TokenMaps
{
  public class DefaultLanguageTokenMap
  {
    public static PreviewGreedyReader<char, IToken> GenerateExactMatches()
    {
      var result = new PreviewGreedyReader<char, IToken>();

      result.Add(new StringTakeWhile<IToken>((c) => !System.Environment.NewLine.Contains(c), (s) => new CommentToken(s)));

      return result;
    }

  }
}
