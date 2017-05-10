using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Language.Core.Extension;
using SergeDev.Language.Core.Implementations;

namespace SergeDev.Language.Contracts.Implementations
{
  public class TokenExpressionMapCollection<T> : BaseTokenExpressionMap<T> where T : class
  {
    private List<ITokenExpressionMap<T>> collection;

    public TokenExpressionMapCollection()
    {
      this.collection = new List<ITokenExpressionMap<T>>();
    }

    public void Add<D>(ITokenExpressionMap<D> map) where D : class, T
    {
      collection.Add(map.Wrap<D, T>());
    }

    public IEnumerable<ITokenExpressionMap<T>> Collection
    {
      get { return collection; }
    }

    public override IReadExpression<T> Map(IToken source)
    {
      var result = default(IReadExpression<T>);
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
