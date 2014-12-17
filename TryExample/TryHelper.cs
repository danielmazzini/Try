using System;
using System.Dynamic;

namespace TryExample
{
public static class Try
{
    public static ITry<T> Create<T>(Func<T> create)
    {
        if (create == null) return Failed<T>(new ArgumentNullException("create"));
        try
        {
            return new Success<T>(create());
        }
        catch (Exception ex)
        {
            return Failed<T>(ex);
        }
    }

    public static ITry<T> Failed<T>(Exception ex)
    {
        return new Failure<T>(ex);
    }

        public static Tuple<bool, Exception> MatchFailure<T>(ITry<T> candidate)
        {
            var fail = candidate as Failure<T>;
            if (fail != null)
            {
                return Tuple.Create(true, fail.GetException());
            }
            return Tuple.Create<bool, Exception>(false, null);
        }
        

        public static ITry<T> FailedFrom<T, U>(ITry<U> originalFail)
        {
            return Failed<T>(((Failure<U>) originalFail).GetException());
        } 

        public static bool MatchSuccess<T>(ITry<T> candidate)
        {
            return typeof(Success<T>) == candidate.GetType();
        }

        
        public static ITry<U> Select<T, U>(this ITry<T> @try, Func<T, U> mapFunc)
        {
            return @try.SelectMany(v => Create(() => mapFunc(v)));
        }
        
    }
}