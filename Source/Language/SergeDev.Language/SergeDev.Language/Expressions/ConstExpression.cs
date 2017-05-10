using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Expressions
{
  public class ConstExpression : ResultingExpression
  {
    private string value;

    public ConstExpression(string value)
    {
      this.value = value;
    }

    public string Value
    {
      get { return value; }
    }
  }
}
