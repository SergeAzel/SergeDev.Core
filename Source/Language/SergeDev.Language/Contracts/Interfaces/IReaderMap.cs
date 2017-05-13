using SergeDev.Language.Core.Interfaces;
using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Core.Interfaces
{
  public interface IReaderMap<S, T> : IMap<IReadOnlyObjectStream<S>, IReadPartial<S, T>>
  {
  }
}
