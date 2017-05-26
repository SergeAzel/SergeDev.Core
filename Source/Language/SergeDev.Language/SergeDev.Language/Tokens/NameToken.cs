using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class NameToken : IToken
  {
    private string value;
    public NameToken(string value)
    {
      this.value = value;
    }

    public bool Critical
    {
      get { return true; }
    }

    public string Value
    {
      get { return value; }
    }
  }
}
