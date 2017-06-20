using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Regex.Tokens
{
  public class CharacterToken : IToken
  {
    public CharacterToken(char value)
    {
      Value = value;
    }

    public char Value
    {
      get;
      private set;
    }
  }
}
