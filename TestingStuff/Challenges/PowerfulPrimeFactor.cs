using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    /**
     * Function that takes a positive integer and returns a string expressing
     * how the number can be made by multiplying powers of its prime factors.
     * All inputs will be positive integers in the range 1 < n < 10,000.
     * If a factor is repeated express it in the form "x^y" where x is the factor and
     * y is the number of repetitions of the factor.
     * (60) ➞ "2^2 x 3 x 5"
     * (10) ➞ "2 x 5"
     */
    public class PowerfulPrimeFactor : IChallenge
    {
        public static string ExpressFactors(int n)
        {
            var primes = GetPrimes(n);

            if (primes.Count == 1)
                return primes[0].ToString();

            var pairs = primes.GroupBy(g => g)
                .Where(w => w.Count() > 1)
                .ToDictionary(t => t.Key, t => t.Count());

            var distinct = primes.Where(t => !pairs.ContainsKey(t)).ToList();

            var sb = new StringBuilder();
            AppendRepeatedFactors(pairs, sb);
            AppendPowers(distinct, pairs, sb);

            return sb.ToString();
        }

        private static void AppendPowers(List<int> distinct, Dictionary<int, int> pairs, StringBuilder sb)
        {
            for (var i = 0; i < distinct.Count; i++)
            {
                if (i == distinct.Count - 1)
                    sb.Append(distinct[i]);
                else if (pairs.Count != 0)
                    sb.Append(" x ")
                        .Append(distinct[i])
                        .Append(" x ");
                else
                    sb.Append(distinct[i])
                        .Append(" x ");
            }
        }

        private static void AppendRepeatedFactors(Dictionary<int, int> pairs, StringBuilder sb)
        {
            for (var i = 0; i < pairs.Count; i++)
            {
                if (i == pairs.Count - 1)
                    sb.Append(pairs.Keys.Select(s => s).ToList()[i])
                        .Append("^")
                        .Append(pairs.Values.Select(s => s).ToList()[i]);
                else
                    sb.Append(pairs.Keys.Select(s => s).ToList()[i])
                        .Append("^")
                        .Append(pairs.Values.Select(s => s).ToList()[i])
                        .Append(" x ");
            }
        }

        private static List<int> GetPrimes(int n)
        {
            var primes = new List<int>();

            for (var div = 2; div <= n; div++)
                while (n % div == 0)
                {
                    primes.Add(div);
                    n /= div;
                }

            return primes;
        }


        public void Show()
        {
            ExpressFactors(10);
        }
    }
}