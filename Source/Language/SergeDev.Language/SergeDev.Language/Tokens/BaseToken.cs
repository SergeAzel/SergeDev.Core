using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public abstract class BaseToken
  {
    public abstract string Value { get; }

    public virtual bool Critical
    {
      get { return true; }
    }
  }
}
