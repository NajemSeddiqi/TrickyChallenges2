using System;
using System.Linq;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    public class Abacus : IChallenge
    {
        public static int Soroban(string[] frame)
        {
            var upperDeck = frame[1].ToList()
                .Select(s => s == 'O' ? '5' : '0')
                .ToArray();

            var lower = frame[3].ToList()
                .Select(s => s == 'O' ? '1' : '0')
                .ToArray();

            var lowerDeck = GetLowerDeck(frame, lower);

            return GetSum(lowerDeck, upperDeck);
        }

        private static string GetLowerDeck(string[] frame, char[] lower)
        {
            var lowerDeck = "";

            for (var i = 0; i < lower.Length; i++)
            {
                int j = 4, m = 1;
                while (frame[j][i] == 'O' && lower[i] == '1')
                {
                    m++;
                    j++;
                }

                if (lower[i] != '1')
                    lowerDeck += "0";
                else
                    lowerDeck += (1 * m).ToString();
            }

            return lowerDeck;
        }

        private static int GetSum(string lower, char[] upperDeck)
        {
            var sum = "";

            for (var i = 0; i < lower.ToCharArray().Length; i++)
            {
                if (lower[i] != '0' || upperDeck[i] != '0')
                    sum += int.Parse(lower[i].ToString()) + int.Parse(upperDeck[i].ToString());
                else
                    sum += "0";
            }

            return int.Parse(sum);
        }

        public void Show()
        {
            Soroban(new[]
            {
                "OOOO||O",
                "||||OO|",
                "-------",
                "|||O|OO",
                "OOOOOOO",
                "OOO|OOO",
                "OOOOO|O",
                "OOOOOO|"
            });
        }
    }
}