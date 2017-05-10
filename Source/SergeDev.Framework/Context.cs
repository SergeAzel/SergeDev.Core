using SergeDev.Core;
using SergeDev.Core.Extension;
using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Framework
{
  public class Context
  {
    private ITypeRegistry typeRegistry;

    public Context()
    {
      typeRegistry = new TypeRegistry();
    }

    public T Get<T>() where T : class
    {
      T result = default(T);
      if (!typeRegistry.Instance<T>().Use(i =>
      {
        result = i;
      }))
      {
        typeRegistry.Instance<IBasicFactory<T>>().Use(f =>
        {
          result = f.Create();
        });
      }
      return result;
    }

    public void UseInstance<T>(Action<T> action) where T : IDisposable
    {
      typeRegistry.Instance<IUsableFactory<T>>().Use(f =>
      {
        f.UseInstance(action);
      });
    }
  }
}
