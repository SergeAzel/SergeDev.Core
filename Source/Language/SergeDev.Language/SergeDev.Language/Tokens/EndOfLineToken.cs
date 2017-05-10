using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class EndOfLineToken : WhitespaceToken
  {
    public static readonly string MatchValue = Environment.NewLine;

    public EndOfLineToken() : base(MatchValue) { }
  }
}
