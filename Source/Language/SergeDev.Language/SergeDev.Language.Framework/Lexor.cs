using SergeDev.Framework;
using SergeDev.Language.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SergeDev.Language.Contracts.Implementations;
using SergeDev.Language.Core.Implementations;
using SergeDev.Contracts.Interfaces;
using SergeDev.Core;

namespace SergeDev.Language.Framework
{
  /// <summary>
  /// Lexor needs a Lexor interface definition.   
  /// Current structure may not be satisfactory for a global definition.
  /// Restructure and give an interface.
  /// </summary>
  public class Lexor : EnumerateUntilNull<IToken>
  {
    private Context context;
    private IObjectStream<char> source;
    private List<ICharacterTokenMap> mappings;

    public Lexor(Context context, IEnumerator<char> source, IEnumerable<ICharacterTokenMap> tokenMappings)
    {
      this.context = context;
      this.source = new BasicObjectStream<char>(source);
      this.mappings = new List<ICharacterTokenMap>(tokenMappings);
    }

    protected override IToken MoveNext()
    {
      var current = default(IToken);
      if (source.HasObject())
      {
        foreach (var map in mappings)
        {
          var reader = map.Map(source.Peek());
          if (reader != null)
          {
            current = reader.Read(source);
          }
        }

        if (current == null)
        {
          current = new UnknownToken(source.Take());
        }
      }
      else
      {
        current = null;
      }
      return current;
    }
  }
}
