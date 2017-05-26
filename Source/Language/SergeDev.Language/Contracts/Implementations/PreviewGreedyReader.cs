using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Core.Implementations;

namespace SergeDev.Language.Core.Implementations
{
  public class PreviewGreedyReader<S, T> : IReadPartial<S, T>
  {
    private List<IReadPartial<S, T>> readers;

    public PreviewGreedyReader(params IReadPartial<S, T>[] readers)
    {
      this.readers = readers.ToList();
    }

    public void Add(IReadPartial<S, T> reader)
    {
      readers.Add(reader);
    }

    public IEnumerable<T> Read(IObjectStream<S> source)
    {
      var previews = Preview(source).ToList();
      var result = default(IEnumerable<T>);

      if (previews.Count > 0)
      {
        var max = previews[0];
        for (int i = 1; i < previews.Count; ++i)
          if (previews[i].Taken > max.Taken)
            max = previews[i];

        //Finalize the amount taken from the basis stream
        source.Take(max.Taken);
        result = max.Results;
      }

      return result;
    }

    private IEnumerable<PreviewResult> Preview(IObjectStream<S> source)
    {
      foreach (var reader in readers)
      {
        var result = Preview(source, reader);
        if (result != null)
          yield return result;
      }
    }

    private static PreviewResult Preview(IObjectStream<S> source, IReadPartial<S, T> reader)
    {
      var previewStream = new PreviewObjectStream<S>(source);
      var preview = reader.Read(previewStream);

      if (preview != null && preview.Any())
      {
        return new PreviewResult()
        {
          Results = preview,
          Taken = previewStream.Taken
        };
      }
      else
      {
        return null;
      }
    }

    private class PreviewResult
    {
      public int Taken;
      public IEnumerable<T> Results;
    }
  }
}
