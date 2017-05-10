using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Expressions
{
  public class CallExpression : ResultingExpression
  {
    private string nameReference;

    private ResultingExpression parameter;

    public CallExpression(string nameReference)
    {
      this.nameReference = nameReference;
      this.parameter = null;
    }

    public CallExpression(string nameReference, ResultingExpression parameter)
    {
      this.nameReference = nameReference;
      this.parameter = parameter;
    }

    public string NameReference
    {
      get { return nameReference; }
    }

    public ResultingExpression Parameter
    {
      get { return parameter; }
    }
  }
}
