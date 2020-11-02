using System;
using System.Linq;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    /**
     * function that takes two parameters, a list of the weights of each item and the number of bags you are carrying.
     * Return True if there are enough bags to contain all the items, otherwise False.
     */
    public class PackingHelp : IChallenge
    {
        public static bool CanFit(int[] weights, int bags)
        {
            var total = weights.ToList().Aggregate((a, b) => a + b);
            var canCarry = bags * 10;

            return total <= canCarry;
        }

        public void Show()
        {
            Console.WriteLine(CanFit(new[] {2, 1, 2, 5, 4, 3, 6, 1, 1, 9, 3, 2}, 4));
            Console.WriteLine(CanFit(new int[] {2, 7, 1, 3, 3, 4, 7, 4, 1, 8, 2}, 4));
        }
    }
}