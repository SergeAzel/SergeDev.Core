using SergeDev.Language.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Syntax.Tokens;

namespace SergeDev.Language.Syntax.TokenMaps
{
  /// <summary>
  /// Deprecated?
  /// </summary>
  public class ExactTokenMatchTree : BaseReaderMap<char, IToken>
  {
    private Dictionary<char, IReaderMap<char, IToken>> children;
    private IReadPartial<char, IToken> localReader;

    public ExactTokenMatchTree()
    {
      this.children = new Dictionary<char, IReaderMap<char, IToken>>();
    }

    public ExactTokenMatchTree(IReadPartial<char, IToken> local)
    {
      this.children = new Dictionary<char, IReaderMap<char, IToken>>();
      this.localReader = local;
    }

    public override IReadPartial<char, IToken> Map(IReadOnlyObjectStream<char> source)
    {
      var result = default(IReadPartial<char, IToken>);

      if (source.HasObject())
      {
        var peekItem = source.Peek();
        if (children.ContainsKey(peekItem))
        {
          result = children[peekItem].Map(new DeepPeekObjectStream<char>(source, 1));
        }
      }

      if (result == null)
        result = localReader;

      return result;
    }
  }
}
