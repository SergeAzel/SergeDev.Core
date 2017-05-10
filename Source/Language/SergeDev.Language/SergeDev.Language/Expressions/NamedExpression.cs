using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Expressions
{
  public class NamedExpression : BaseExpression
  {
    private string name;
    private ResultingExpression value;

    public NamedExpression(string name, ResultingExpression value)
    {
      this.name = name;
      this.value = value;
    }

    public string Name
    {
      get { return name; }
    }

    public BaseExpression Value
    {
      get { return value; }
    }
  }
}
