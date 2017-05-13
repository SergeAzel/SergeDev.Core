using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class UnknownToken : BaseToken
  {
    private string value;

    public UnknownToken(string value)
    {
      this.value = value;
    }

    public override string Value
    {
      get { return value; }
    }
  }
}
