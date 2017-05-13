using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Language.Core.Extension;
using SergeDev.Language.Core.Implementations;
using SergeDev.Contracts.Interfaces;

namespace SergeDev.Language.Core.Implementations
{
  public class ReaderMapCollection<S, T> : BaseReaderMap<S, T> where T : class
  {
    private List<IReaderMap<S, T>> collection;

    public ReaderMapCollection()
    {
      this.collection = new List<IReaderMap<S, T>>();
    }

    public void Add<D>(IReaderMap<S, D> map) where D : class, T
    {
      collection.Add(map.Wrap<S, D, T>());
    }

    public IEnumerable<IReaderMap<S, T>> Collection
    {
      get { return collection; }
    }

    public override IReadPartial<S, T> Map(IReadOnlyObjectStream<S> source)
    {
      var result = default(IReadPartial<S, T>);
      foreach (var map in collection)
      {
        result = map.Map(source);
        if (result != null)
          break;
      }
      return result;
    }
  }
}
