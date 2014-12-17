using System;
using System.Collections.Generic;

namespace TryExample
{
    public interface ITry<T> : IEnumerable<T>
    {
        T Value { get; }

        ITry<U> SelectMany<U>(Func<T, ITry<U>> mapper);

        bool IsSuccess { get; }
    }
}