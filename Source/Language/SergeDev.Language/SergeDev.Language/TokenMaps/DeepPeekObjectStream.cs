using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.TokenMaps
{
  /// <summary>
  /// Deprecated?
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class DeepPeekObjectStream<T> : IReadOnlyObjectStream<T>
  {
    private IReadOnlyObjectStream<T> wrapped;
    private int baseDepth;
    public DeepPeekObjectStream(IReadOnlyObjectStream<T> wrapped, int baseDepth)
    {
      this.wrapped = wrapped;
      this.baseDepth = baseDepth;
    }

    public bool HasObject()
    {
      return HasObject(0);
    }

    public bool HasObject(int depth)
    {
      return wrapped.HasObject(baseDepth + depth);
    }

    public T Peek()
    {
      return Peek(0);
    }

    public T Peek(int depth)
    {
      return wrapped.Peek(baseDepth + depth);
    }
  }
}
