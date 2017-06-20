using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core;
using SergeDev.Core.Extension;

namespace SergeDev.Language.Framework
{
  public class MatchBuilder<S, T>
  {
    private List<Func<IObjectStream<S>, IEnumerable<S>>> acquisitionTransforms;
    private Func<IEnumerable<S>, IEnumerable<T>> tokenizeTransform;

    public MatchBuilder()
    {
      acquisitionTransforms = new List<Func<IObjectStream<S>, IEnumerable<S>>>();
    }

    public MatchBuilder<S, T> Transform(Func<IObjectStream<S>, IEnumerable<S>> initial)
    {
      acquisitionTransforms.Add(initial);
      return this;
    }

    public MatchBuilder<S, T> Tokenize(Func<IEnumerable<S>, IEnumerable<T>> tokenize)
    {
      this.tokenizeTransform = tokenize;
      return this;
    }

    public MatchBuilder<S, T> Tokenize(Func<S, T> tokenize)
    {
      return Tokenize(ie => ie.Select(s => tokenize(s)));
    }

    public IReadPartial<S, T> Create()
    {
      return new MatchTransforms<S, T>(acquisitionTransforms, tokenizeTransform);
    }


    private class MatchTransforms<S, T> : IReadPartial<S, T>
    {
      private List<Func<IObjectStream<S>, IEnumerable<S>>> acquisitionTransforms;
      private Func<IObjectStream<S>, IEnumerable<S>> untilTransform;
      private Func<IEnumerable<S>, IEnumerable<T>> tokenize;

      public MatchTransforms(List<Func<IObjectStream<S>, IEnumerable<S>>> acquisitionTransforms, Func<IObjectStream<S>, IEnumerable<S>> untilTransform, Func<IEnumerable<S>, IEnumerable<T>> tokenize)
      {
        this.initialTransform = initialTransform;
        this.untilTransform = untilTransform;
        this.tokenize = tokenize;
      }

      public IEnumerable<T> Read(IObjectStream<S> source)
      {
        return tokenize(Yield(source));
      }

      private IEnumerable<S> Yield(IObjectStream<S> source)
      {
        bool valid = true;
        if (initialTransform != null)
        {
          valid = false;
          foreach (var item in initialTransform(source))
          {
            yield return item;
            valid = true;
          }
        }
        
        if (valid && untilTransform != null)
        {
          foreach (var item in untilTransform(source))
          {
            yield return item;
          }
        }
      }
    }
  }
}
