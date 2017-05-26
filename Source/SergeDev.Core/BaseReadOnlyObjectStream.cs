using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public abstract class BaseReadOnlyObjectStream<S> : IReadOnlyObjectStream<S>
  {
    public virtual bool HasObject()
    {
      return HasObject(0);
    }

    public virtual S Peek()
    {
      return Peek(0);
    }

    public abstract bool HasObject(int depth);

    public abstract S Peek(int depth);
  }
}
