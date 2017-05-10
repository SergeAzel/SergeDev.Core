using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Core.Interfaces
{
  public interface ICharacterTokenMap : IMap<char, IReadToken>
  {
  }
}
