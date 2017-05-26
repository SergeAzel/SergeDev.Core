using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public abstract class BaseObjectStream<S> : BaseReadOnlyObjectStream<S>, IObjectStream<S>
  {
    public virtual void Discard()
    {
      Discard(1);
    }

    public virtual S Take()
    {
      return (Take(1) ?? Enumerable.Empty<S>()).FirstOrDefault();
    }

    public abstract void Discard(int count);

    public abstract IEnumerable<S> Take(int count);
  }
}
