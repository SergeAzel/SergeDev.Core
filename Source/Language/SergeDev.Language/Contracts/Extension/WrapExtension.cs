using SergeDev.Language.Core.Implementations;
using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Core.Extension
{
  public static class WrapExtension
  {
    public static IReaderMap<S, B> Wrap<S, T, B>(this IReaderMap<S, T> wrapped) where T : class, B where B : class
    {
      return new WrappedReaderMap<S, T, B>(wrapped);
    }

    public static IReadPartial<S, B> Wrap<S, T, B>(this IReadPartial<S, T> wrapped) where T : class, B where B : class
    {
      return new WrappedReadPartial<S, T, B>(wrapped);
    }
  }
}
