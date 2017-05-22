using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public class CachedExpression<T>
  {
    private Func<T> expression;
    private T result;
    private bool expired;

    public CachedExpression(Func<T> expression)
    {
      this.expression = expression;
      result = default(T);
      expired = true;
    }

    public T Evaluate()
    {
      if (expired)
      {
        result = expression();
        expired = false;
      }

      return result;
    }

    public void Expire()
    {
      expired = true;
    }
  }
}
