using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Regex.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core.Implementations;
using SergeDev.Language.Framework;
using SergeDev.Language.Regex.Extensions;

namespace SergeDev.Language.Regex
{
  public class Lexor : IReadPartial<char, IToken>
  {
    private PreviewGreedyReader<char, IToken> reader;
    public Lexor()
    {
      reader = new PreviewGreedyReader<char, IToken>();

      //All the standard operation tokens
      reader.Add(new MatchBuilder<char, IToken>().InitialMatch('(').Tokenize(p => new OpenParenToken()).Create());
      reader.Add(new MatchBuilder<char, IToken>().InitialMatch(')').Tokenize(p => new CloseParenToken()).Create());
      reader.Add(new MatchBuilder<char, IToken>().InitialMatch('|').Tokenize(p => new OrToken()).Create());
      reader.Add(new MatchBuilder<char, IToken>().InitialMatch('-').Tokenize(p => new RangeToken()).Create());
      reader.Add(new MatchBuilder<char, IToken>().InitialMatch('*').Tokenize(p => new ZeroToManyToken()).Create());
      reader.Add(new MatchBuilder<char, IToken>().InitialMatch('+').Tokenize(p => new OneToManyToken()).Create());
      reader.Add(new MatchBuilder<char, IToken>().UntilComparison(c => !IsAlphaNumeric(c)).Tokenize(c => new CharacterToken(c)).Create());
    }

    private bool IsAlphaNumeric(char input)
    {
      return ((input >= '0' && input <= '9') 
           || (input >= 'A' && input <= 'Z') 
           || (input >= 'a' || input <= 'z'));
    }

    public IEnumerable<IToken> ReadAll(IObjectStream<char> source)
    {
      while (source.HasObject())
        foreach (var token in Read(source))
          yield return token;
    }

    public IEnumerable<IToken> Read(IObjectStream<char> source)
    {
      return reader.Read(source);
    }
  }
}
