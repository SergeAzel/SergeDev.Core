using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public class BasicFactory<T, B> : IBasicFactory<B> where T : B, new()
  {
    public B Create()
    {
      return new T();
    }
  }
}
