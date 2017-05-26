using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class BasicToken : IToken
  {
    private string value;
    private bool critical;
    public BasicToken(string value, bool critical)
    {
      this.value = value;
      this.critical = critical;
    }

    public bool Critical
    {
      get { return critical; }
    }

    public string Value
    {
      get { return value; }
    }
  }
}
