using System;
using System.Linq;
using System.Text;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    /**
     * A smooth sentence is one where the last letter of each word is identical to the first letter the following word
     * (and not case sensitive, so "A" would be the same as "a").
     */
    public class SmoothSentences : IChallenge
    {
        public static bool IsSmooth(string sentence)
        {
            var arr = sentence.Split(' ').ToArray();

            for (var i = 0; i < arr.Length - 1; i++)
                if (!arr[i + 1].ToLower().StartsWith(arr[i].ToLower()[arr[i].Length - 1].ToString()))
                    return false;

            return true;
        }

        public void Show()
        {
            Console.WriteLine(IsSmooth("Rita asks Sam mean numbered dilemmas"));
        }
    }
}