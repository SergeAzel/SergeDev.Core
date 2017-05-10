using SergeDev.Language.Syntax.Interfaces;
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
  public class StandardTokenMap : ICharacterTokenReaderMap
  {
    public IReadPartial<char, BaseToken> Map(char source, IReadPartial<char, BaseToken> otherwise)
    {
      throw new NotImplementedException();
    }

    IReadPartial<char, BaseToken> IMap<char, IReadPartial<char, BaseToken>>.Map(char source)
    {
      throw new NotImplementedException();
    }
  }
}
