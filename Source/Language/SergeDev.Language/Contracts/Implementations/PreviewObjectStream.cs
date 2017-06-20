using SergeDev.Contracts.Interfaces;
using SergeDev.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Core
{
  /// <summary>
  /// Emulates a manageable object stream that merely previews a backing object stream.
  /// </summary>
  public class PreviewObjectStream<S> : BaseObjectStream<S>
  {
    private int taken;
    private IObjectStream<S> basis;

    public PreviewObjectStream(IObjectStream<S> basis)
    {
      taken = 0;
      this.basis = basis;
    }

    /// <summary>
    /// The quantity of records taken or discarded from the basis object stream.
    /// </summary>
    public int Taken
    {
      get { return taken; }
    }

    /// <summary>
    /// Finalizes the preview, removing from backing source the quantity taken.
    /// Calling this is optional.
    /// </summary>
    public void Commit()
    {
      basis.Discard(taken);
      taken = 0;
    }

    public override void Discard(int count)
    {
      for (var max = taken + count; taken < max && basis.HasObject(taken); ++taken) ;
    }

    public override bool HasObject(int depth)
    {
      return basis.HasObject(taken + depth);
    }

    public override S Peek(int depth)
    {
      return basis.Peek(taken + depth);
    }

    public override IEnumerable<S> Take(int count)
    {
      for (var max = taken + count; taken < max && basis.HasObject(taken); ++taken)
        yield return basis.Peek(taken);
    }
  }
}
