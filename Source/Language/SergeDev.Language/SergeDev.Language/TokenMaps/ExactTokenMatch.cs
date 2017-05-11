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
  public class TokenMatch : BaseReaderMap<char, BaseToken>
  {
    public IReadPartial<char, BaseToken> Map(char source)
    {

    }
  }
}
