using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Expressions
{
  public class BlockExpression : ResultingExpression 
  {
    private IEnumerable<BaseExpression> children;

    public BlockExpression(IEnumerable<BaseExpression> children)
    {
      this.children = children;
    }

    public IEnumerable<BaseExpression> Children
    {
      get { return children; }
    }
  }
}
