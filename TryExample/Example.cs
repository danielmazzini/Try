using System;
using System.Collections.Generic;
using System.Linq;

namespace TryExample
{
    public class Example
    {
        public ITry<int> RunOk()
        {
            var numbers = GetNumbers();
            var result = GetResult(numbers);

            return result;


        }

        public ITry<int> RunKO()
        {
            var numbers = GetException();
            var result = GetResult(numbers);
            return result;
        }

        private ITry<IEnumerable<int>> GetException()
        {
            return Try.Create(GetExceptionResult);
        }

        private IEnumerable<int> GetExceptionResult()
        {
            throw new ApplicationException("porque si");
        } 

        private ITry<int> GetResult(ITry<IEnumerable<int>> numbers)
        {
            return numbers.Select(ints => ints.Sum(x => x));
        }

        public ITry<IEnumerable<int>> GetNumbers()
        {
            return Try.Create(() => Enumerable.Range(0, 5));
        }
    }
}