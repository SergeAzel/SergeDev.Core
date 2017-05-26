using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public interface IToken
  {
    string Value { get; }

    bool Critical { get; }
  }
}
