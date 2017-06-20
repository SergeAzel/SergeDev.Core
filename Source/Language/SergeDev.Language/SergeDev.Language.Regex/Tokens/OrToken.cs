using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Tokens
{
  public class OrToken : IToken
  {
    public const char Or = '|';

    public char Value { get { return Or; } }
  }
}
