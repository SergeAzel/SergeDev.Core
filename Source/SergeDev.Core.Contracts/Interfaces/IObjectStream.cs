﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Contracts.Interfaces
{
  public interface IObjectStream<T> : IReadOnlyObjectStream<T>
  {
    T Take();

    IEnumerable<T> Take(int count);

    void Discard();

    void Discard(int count);
  }
}
