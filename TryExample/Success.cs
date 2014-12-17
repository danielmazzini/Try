using System;
using System.Collections;
using System.Collections.Generic;

namespace TryExample
{
    public class Success<T> : ITry<T>
    {
        public Success(T newValue)
        {
            Value = newValue;
        }
        public bool IsSuccess { get { return true; } }
        public T Value { get; private set; }
        public ITry<U> SelectMany<U>(Func<T, ITry<U>> mapper)
        {
            if (mapper == null) return new Failure<U>(new ArgumentNullException("mapper"));
            try
            {
                return mapper(Value);
            }
            catch (Exception ex)
            {
                return new Failure<U>(ex);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}