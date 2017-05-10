using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public class BasicUsableFactory<T, B> : IUsableFactory<B> where T : B, new() where B : IDisposable
  {
    public void UseInstance(Action<B> action)
    {
      using (B item = new T())
      {
        action(item);
      }
    }
  }
}