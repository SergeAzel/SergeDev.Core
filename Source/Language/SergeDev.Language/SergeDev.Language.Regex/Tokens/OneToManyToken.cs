using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Tokens
{
  public class OneToManyToken : IToken
  {
    public const char OneToMany = '+';

    public char Value { get { return OneToMany; } }
  }
}
