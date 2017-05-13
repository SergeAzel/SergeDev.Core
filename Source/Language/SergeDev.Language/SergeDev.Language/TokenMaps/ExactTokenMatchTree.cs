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
  public class ExactTokenMatchTree : BaseReaderMap<char, BaseToken>
  {
    private Dictionary<char, IReaderMap<char, BaseToken>> children;
    private IReadPartial<char, BaseToken> localReader;

    public ExactTokenMatchTree()
    {
      this.children = new Dictionary<char, IReaderMap<char, BaseToken>>();
    }

    public ExactTokenMatchTree(IReadPartial<char, BaseToken> local)
    {
      this.children = new Dictionary<char, IReaderMap<char, BaseToken>>();
      this.localReader = local;
    }

    public override IReadPartial<char, BaseToken> Map(IReadOnlyObjectStream<char> source)
    {
      var result = default(IReadPartial<char, BaseToken>);

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
