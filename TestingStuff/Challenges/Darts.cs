using System;
using System.Collections.Generic;
using System.Linq;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    //Fuck this challenge
    public class Darts : IChallenge
    {
        public static string[] DartsSolver(int[] sections, int darts, int target)
        {
            var once = new List<int>();
            var twice = new List<int>();

            for (var i = 0; i < sections.Length; i++)
            {
                for (var j = 0; j < sections.Length; j++)
                {
                    if (j == i) continue;
                    if (!sections.Contains(target - (sections[i] + sections[j]))) continue;
                    once.Add(sections[i]);
                    once.Add(sections[j]);
                }

                if (!sections.Contains(target - (sections[i] * (darts - 1)))) continue;
                twice.Add((target - (sections[i] * (darts - 1))));
                for (var x = 0; x < darts - 1; x++)
                    twice.Add(sections[i]);
            }

            twice.Sort();
            var distinctOne = once.Distinct();

            var left = distinctOne.Take(darts).ToList();
            left.Sort();

            var right = distinctOne.Skip(darts).ToList();

            right.Add(target - right.Sum());
            right.Sort();

            string toAddLeft = "", toAddRight = "", toAdd = "";
            for (var i = 0; i < darts; i++)
            {
                if (left.Count == darts)
                    toAddLeft += i <= 0 ? left[i].ToString() : "-" + left[i];
                if (right.Count == darts)
                    toAddRight += i <= 0 ? right[i].ToString() : "-" + right[i];
                if (twice.Count == darts)
                    toAdd += i <= 0 ? twice[i].ToString() : "-" + twice[i];
            }


            var solutions = new List<string>();

            if (left.Count == darts)
                solutions.Add(toAddLeft);
            if (twice.Count == darts)
                solutions.Add(toAdd);
            if (right.Count == darts)
                solutions.Add(toAddRight);


            return solutions.ToArray();
        }


        public void Show()
        {
            DartsSolver(new int[] {3, 7, 11, 14, 18, 20, 25}, 3, 32); // {"3-11-18", "7-7-18", "7-11-14"}
        }
    }
}