using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Expressions
{
  public class ReferenceExpression : ResultingExpression
  {
    private BaseExpression expression;

    public ReferenceExpression(BaseExpression expression)
    {
      this.expression = expression;
    }

    public BaseExpression Expression { get; }
  }
}
