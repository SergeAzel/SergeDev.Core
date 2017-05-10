using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Syntax.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Interfaces
{
  //Simple explicitly defined interface for character maps to token readers
  public interface ICharacterTokenReaderMap : IReaderMap<char, BaseToken>
  {
  }
}
