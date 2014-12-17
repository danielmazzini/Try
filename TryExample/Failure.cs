using System;
using System.Collections;
using System.Collections.Generic;

namespace TryExample
{
public class Failure<T> : ITry<T>
{
    private readonly Exception ex;
    public Failure(Exception ex)
    {
        this.ex = ex;
    }
    public T Value
    {
        get { throw new InvalidOperationException("Can't get value for failed Try"); }
    }
    public ITry<U> SelectMany<U>(Func<T, ITry<U>> bindFunc)
    {
        return new Failure<U>(ex);
    }
    public bool IsSuccess
    {
        get { return false; }
    }

    public Exception GetException()
    {
        return ex;
    }
        public IEnumerator<T> GetEnumerator()
        {
            yield break;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
