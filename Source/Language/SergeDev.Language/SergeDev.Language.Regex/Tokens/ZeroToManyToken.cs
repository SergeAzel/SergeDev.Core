using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Tokens
{
  public class ZeroToManyToken : IToken
  {
    public const char ZeroToMany = '*';

    public char Value { get { return ZeroToMany; } }
  }
}
