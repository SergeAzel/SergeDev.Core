using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Syntax.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Language.Syntax.TokenMaps
{
  public class BasicExactTokenMatch : BaseExactTokenMatch
  {
    private Func<IObjectStream<char>, IToken> reader;
    public BasicExactTokenMatch(string tokenString, Func<IObjectStream<char>, IToken> reader) : base(tokenString)
    {
      this.reader = reader;
    }

    public override IEnumerable<IToken> Read(IObjectStream<char> source)
    {
      yield return reader(source);
    }
  }
}
