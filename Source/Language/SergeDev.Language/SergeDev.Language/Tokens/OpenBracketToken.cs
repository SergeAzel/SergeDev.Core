using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class OpenBracketToken : IToken
  {
    public const string MatchValue = "}";

    public bool Critical
    {
      get { return true; }
    }

    public string Value
    {
      get { return MatchValue; }
    }
  }
}
