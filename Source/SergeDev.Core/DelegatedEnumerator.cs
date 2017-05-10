using SergeDev.Contracts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public class DelegatedEnumerator<T> : IEnumerator<T>
  {
    private Func<bool> read;
    private Func<T> getCurrent;

    public DelegatedEnumerator(Func<bool> read, Func<T> getCurrent)
    {
      this.read = read;
      this.getCurrent = getCurrent;
    }

    public T Current
    {
      get { return getCurrent(); }
    }

    object IEnumerator.Current
    {
      get { return this.Current; }
    }

    public bool MoveNext()
    {
      return read();
    }

    public void Reset() { } 

    public void Dispose()
    {
      Dispose(true);
    }

    ~DelegatedEnumerator()
    {
      Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        read = null;
        getCurrent = null;

        GC.SuppressFinalize(this);
      }
    }

  }
}
