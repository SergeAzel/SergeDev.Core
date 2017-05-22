using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Core.Implementations
{
  public class StringTakeWhile<T> : TakeWhile<char, T>
  {
    public StringTakeWhile(Func<char, bool> condition, Func<string, T> tokenize) : base(condition, (c) => tokenize(new string(c.ToArray()))) { }
  }
}
