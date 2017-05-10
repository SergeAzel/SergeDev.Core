using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public class BasicObjectStream<T> : IObjectStream<T>
  {
    private IEnumerator<T> source;
    private T current;
    private bool isValid;

    public BasicObjectStream(IEnumerator<T> source)
    {
      this.source = source;
      if (source.MoveNext())
      {
        current = source.Current;
        isValid = true;
      }
      else
      {
        current = default(T);
        isValid = false;
      }
    }

    public bool HasObject()
    {
      return isValid;
    }

    public T Peek()
    {
      return current;
    }

    public T Take()
    {
      T result = default(T);

      if (isValid)
      {
        result = current;
        if (source.MoveNext())
        {
          current = source.Current;
        }
        else
        {
          isValid = false;
        }
      }

      return result;
    }
  }
}
