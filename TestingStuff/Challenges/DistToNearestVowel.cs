using System;
using System.Collections.Generic;
using System.Linq;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    /**
     * function that takes in a string and for each character,
     * returns the distance to the nearest vowel in the string.
     * If the character is a vowel itself, return 0.
     * All input strings will contain at least one vowel.
     */
    public class DistToNearestVowel : IChallenge
    {
        public static int[] DistanceToNearestVowel(string str)
        {
            var chars = str.ToLower().ToCharArray();
            var dists = new List<int>();

            for (var i = 0; i < chars.Length; i++)
            {
                int left = 0, right = 0;
                bool touched = false, hitVowel = false;

                for (var r = i; r < chars.Length; r++)
                    if (IsVowel(chars[r]))
                        break;
                    else
                        right++;


                for (var l = i; l >= 0; l--)
                    if (IsVowel(chars[l]))
                    {
                        hitVowel = true;
                        break;
                    }
                    else
                    {
                        left++;
                        touched = true;
                    }


                if (touched && i != chars.Length - 1)
                {
                    if (hitVowel)
                        dists.Add(right < left ? right : left);
                    else
                        dists.Add(right);
                }
                else if (i == chars.Length - 1)
                    dists.Add(left);
                else
                    dists.Add(right);
            }

            return dists.ToArray();
        }

        private static bool IsVowel(char s)
        {
            return s == 'a' || s == 'i' || s == 'e' || s == 'o' || s == 'u';
        }

        public void Show()
        {
            DistanceToNearestVowel("abcdabcd").ToList().ForEach(Console.Write);
        }
    }
}