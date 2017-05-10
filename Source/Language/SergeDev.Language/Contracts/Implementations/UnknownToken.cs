using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Core.Implementations
{
  public class UnknownToken : IToken
  {
    private char value;
    public UnknownToken()
    {
      value = '\0';
    }

    public UnknownToken(char value)
    {
      this.value = value;
    }

    public string Value
    {
      get { return value.ToString(); }
    }
  }
}
