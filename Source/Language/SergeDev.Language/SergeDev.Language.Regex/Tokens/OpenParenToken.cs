using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Tokens
{
  public class OpenParenToken : IToken
  {
    public const char OpenParen = '(';

    public char Value { get { return OpenParen; } }
  }
}
