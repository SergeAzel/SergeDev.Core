using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Tokens
{
  public class RangeToken : IToken
  {
    public const char Range = '-';

    public char Value { get { return Range; } }
  }
}
