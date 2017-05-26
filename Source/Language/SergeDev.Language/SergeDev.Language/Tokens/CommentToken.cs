using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class CommentToken : BasicToken 
  {
    public CommentToken(string value) : base(value, false) { }
  }
}
