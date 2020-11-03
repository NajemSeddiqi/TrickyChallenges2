using System;
using System.Text;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    /**
     * A centered hexagonal number is a centered figurate number that represents a hexagon with a dot in the center and
     * all other dots surrounding the center dot in a hexagonal lattice.
     * HexagonalNumbers takes an integer n and returns "Invalid" if n is not a centered hexagonal number or
     * its illustration as a multiline rectangular string otherwise
     */
    public class CenteredHexagonalNumber : IChallenge
    {
        public static string HexagonalNumbers(int n = 1)
        {
            return !IsValid(n) ? "Invalid" : GetCenteredHexagon(n).ToString();
        }

        private static StringBuilder GetCenteredHexagon(int n)
        {
            var sb = new StringBuilder();
            int x = 0, y = (int) GetRoot(n), length = (int) GetRoot(n) * 2 - 1;

            for (var i = 0; i < length; i++)
            {
                var sequence = GetRoot(n) + x;
                sb.Append(GetSpaces(y));

                for (var j = 0; j < sequence; j++)
                    sb.Append("o").Append(j != (int) sequence - 1 ? " " : "");

                sb.Append(GetSpaces(y)).Append(i != (int) length - 1 ? "\n" : "");

                if (i < GetRoot(n) - 1)
                {
                    x++;
                    y--;
                }

                if (!(i >= GetRoot(n) - 1)) continue;
                x--;
                y++;
            }

            return sb;
        }

        private static string GetSpaces(int i)
        {
            var space = "";
            for (var j = 0; j < i; j++)
                space += " ";

            return space;
        }

        private static bool IsValid(int n)
        {
            var x = GetRoot(n);
            return Math.Abs(x - (int) x) == 0;
        }

        private static double GetRoot(int n)
        {
            // finding the root
            // https://en.wikipedia.org/wiki/Centered_hexagonal_number#:~:text=The%20first%20few%20centered%20hexagonal,%2C%20721%2C%20817%2C%20919.
            return (3 + Math.Sqrt(12 * n - 3)) / 6;
        }

        public void Show()
        {
            HexagonalNumbers(19);
        }
    }
}