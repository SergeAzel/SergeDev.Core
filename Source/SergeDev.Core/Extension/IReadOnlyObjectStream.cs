using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core.Extension
{
  public static class IReadOnlyObjectStream
  {
    public static IEnumerable<T> PeekMany<T>(this Contracts.Interfaces.IReadOnlyObjectStream<T> me, int count)
    {
      while (!me.HasObject(count - 1) && count > 0) --count;

      for (var i = 0; i < count; ++i)
      {
        yield return me.Peek(i);
      }
    }
  }
}
