using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core.Implementations;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Syntax.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.TokenMaps
{
  public abstract class BaseExactTokenMatch : IReadPartial<char, IToken>
  {
    private string tokenString;
    public BaseExactTokenMatch(string tokenString)
    {
      this.tokenString = tokenString;
    }

    public string Match { get { return tokenString; } }

    public abstract IEnumerable<IToken> Read(IObjectStream<char> source);
  }
}