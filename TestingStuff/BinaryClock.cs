using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingStuff.Models;

namespace TestingStuff
{
    public class BinaryClock : IChallenge
    {
        public static string[] GetTime(string str)
        {
            var dimensional = GetDimensionalArray(GetBinaries(str));

            StringBuilder sbOne = new StringBuilder(), sbTwo = new StringBuilder();
            string three = "", four = "";

            for (var j = 0; j < 6; j++)
            {
                sbOne.Append(dimensional[0, j]);
                sbTwo.Append(dimensional[1, j]);
                three += dimensional[2, j];
                four += dimensional[3, j];
            }

            AddAppropriateSpaces(sbOne, sbTwo);

            return new[] {sbOne.ToString(), sbTwo.ToString(), three, four};
        }

        private static void AddAppropriateSpaces(StringBuilder sbOne, StringBuilder sbTwo)
        {
            sbOne.Replace("0", " ", 0, 1)
                .Replace("0", " ", 2, 1)
                .Replace("0", " ", 4, 1);

            sbTwo.Replace("0", " ", 0, 1);
        }

        private static string[,] GetDimensionalArray(string[] bytes)
        {
            string[,] dimensional = new string[4, 6];

            for (var i = 0; i < bytes.Length; i++)
            {
                var c = bytes[i].ToCharArray();
                for (var j = 0; j < c.Length; j++)
                {
                    dimensional[j, i] = c[j].ToString();
                }
            }

            return dimensional;
        }

        private static string[] GetBinaries(string str)
        {
            var bytes = new string[6];
            var s = str.Split(':').Aggregate((curr, next) => curr + next);

            for (var i = 0; i < s.ToCharArray().Length; i++)
            {
                var c = Convert.ToString(s[i], 2);
                bytes[i] = c.Substring(c.Length - 4, 4);
            }

            return bytes;
        }

        public void Show()
        {
            GetTime("10:37:49");
        }
    }
}