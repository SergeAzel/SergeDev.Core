using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Syntax.Tokens;
using SergeDev.Language.Core.Implementations;

namespace SergeDev.Language.Syntax.TokenMaps
{
  public class StandardTokenMap : BaseReaderMap<char, BaseToken>
  {
    private List<IReaderMap<char, BaseToken>> subMaps;
    private IReadPartial<char, BaseToken> otherwise;

    public StandardTokenMap(IEnumerable<IReaderMap<char, BaseToken>> subMaps, IReadPartial<char, BaseToken> otherwise)
    {
      this.subMaps = subMaps.ToList();
      this.otherwise = otherwise;
    }

    public void AddSubMap(IReaderMap<char, BaseToken> map)
    {
      subMaps.Add(map);
    }

    public override IReadPartial<char, BaseToken> Map(char source)
    {
      return null;
    }
  }
}
