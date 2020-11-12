using System;
using System.Collections.Generic;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    public class GeneratePermutations : IChallenge
    {
        public static string Permutations(string s)
        {
            var arr = new List<string>();
            Permute(s, arr);

            arr.Sort();
            return string.Concat(arr).TrimEnd();
        }

        private static void Permute(string s, ICollection<string> arr, string pr = "")
        {
            if (string.IsNullOrEmpty(s))
                arr.Add(pr + " ");

            // Debug this and you'll see after a certain number of iterations s becomes the original string again
            // and the pr becomes the next char in the string'
            for (var i = 0; i < s.Length; i++)
                Permute(s.Remove(i, 1), arr, pr + s[i]);
        }

        public void Show()
        {
            Permutations("FELT");
        }
    }
}