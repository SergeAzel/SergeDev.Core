using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Language.Core.Interfaces
{
  public interface IReadToken : IReadPartial<char, IToken> { }
}
