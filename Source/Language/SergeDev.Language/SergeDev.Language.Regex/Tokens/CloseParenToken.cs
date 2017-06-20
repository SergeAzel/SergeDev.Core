using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Tokens
{
  public class CloseParenToken : IToken
  {
    public const char CloseParen = '(';

    public char Value { get { return CloseParen; } }
  }
}
