using System;
using System.Linq;
using TryExample;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
            var tryOk = ex.RunOk();
            var tryKo = ex.RunKO();

            if (Try.MatchSuccess(tryOk))
                Console.WriteLine(tryOk.First());

            var match = Try.MatchFailure(tryKo);
            if (match.Item1)
                Console.WriteLine(match.Item2);
        }
    }
}
