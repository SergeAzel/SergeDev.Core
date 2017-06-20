using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core.Extension
{
  public static class Object
  {
    public static bool Use<T>(this T me, Action<T> action)
    {
      if (me != null)
      {
        action(me);
      }
      return (me != null);
    }

    public static IEnumerable<S> Yield<S>(this S me)
    {
      yield return me;
    }
  }
}
