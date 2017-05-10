using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Contracts.Implementations
{
  public abstract class EnumerateUntilNull<T> : IEnumerator<T>
  {
    private T current;

    public T Current
    {
      get { return current; }
    }

    protected abstract T MoveNext();

    object IEnumerator.Current
    {
      get { return this.Current; }
    }

    bool IEnumerator.MoveNext()
    {
      current = MoveNext();
      return (current != null);
    }

    void IEnumerator.Reset() { }

    void IDisposable.Dispose()
    {
      Dispose();
    }

    protected virtual void Dispose()
    {
      current = default(T);
    }
  }
}
