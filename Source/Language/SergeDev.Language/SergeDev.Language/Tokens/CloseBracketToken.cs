using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class CloseBracketToken : IToken
  {
    public const string MatchValue = "}";

    public string Value
    {
      get { return MatchValue; }
    }

    public bool Critical
    {
      get { return true; }
    }
  }
}
