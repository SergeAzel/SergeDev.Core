using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class CommentBeginLineToken : BaseToken
  {
    public const string MatchValue = "//";

    public override string Value
    {
      get { return MatchValue; }
    }
  }
}
