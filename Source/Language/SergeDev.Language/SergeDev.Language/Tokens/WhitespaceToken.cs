using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class WhitespaceToken : BaseToken
  {
    private string value;
    public WhitespaceToken(string value)
    {
      this.value = value;
    }

    public override string Value
    {
      get { return value; }
    }

    public override bool Critical
    {
      get { return false; }
    }
  }
}
