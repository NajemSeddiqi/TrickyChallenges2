using System.Collections.Generic;
using System.Linq;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    /**
     * Establish which kind of Poker combination is present in a deck of five cards.
     * Every card is a string containing the card value (with the upper-case initial for face-cards)
     * and the lower-case initial for suits, as in the examples below:
     * "Ah" ➞ Ace of hearts
     * "Ks" ➞ King of spades
     * "3d" ➞ Three of diamonds
     * "Qc" ➞ Queen of clubs
     * "10c" ➞ Ten of clubs
     */
    public class PokerHand : IChallenge
    {
        public static string PokerHandRanking(IEnumerable<string> hand)
        {
            //In order to avoid multiple enumerations of the same array/list
            var h = hand.ToList();

            var cardValues = h.Select(s => s.Substring(0, s.Length - 1))
                .Select(MapRoyalToNumbers)
                .ToList();

            var suits = h.Select(s => s.Substring(s.Length - 1))
                .ToList();

            var distinct = cardValues.GroupBy(g => g)
                .Where(w => w.Count() > 1)
                .ToDictionary(t => t.Key, t => t.Count());

            return distinct.Count >= 1 ? GetKind(distinct) : GetFlushOrStraightKind(cardValues, suits);
        }

        private static string GetKind(Dictionary<string, int> cards)
        {
            string kind;
            var n = cards.Select(s => s.Value)
                .Aggregate((a, b) => a + b);

            switch (n)
            {
                case 5:
                    kind = "Full House";
                    break;
                case 4:
                    kind = cards.Count > 1 ? "Two Pair" : "Four of a Kind";
                    break;
                case 3:
                    kind = "Three of a Kind";
                    break;
                case 2:
                    kind = "Pair";
                    break;
                default:
                    kind = "High Card";
                    break;
            }

            return kind;
        }

        private static string GetFlushOrStraightKind(IEnumerable<string> cards, IEnumerable<string> suits)
        {
            var c = cards as string[] ?? cards.ToArray();
            var s = suits as string[] ?? suits.ToArray();

            return IsStraight(c) && IsFlush(s) && c.Contains("14") ? "Royal Flush" :
                IsStraight(c) && IsFlush(s) ? "Straight Flush" :
                IsStraight(c) ? "Straight" :
                IsFlush(s) ? "Flush" : "High Card";
        }

        private static bool IsStraight(IEnumerable<string> cards)
        {
            var c = cards.Select(int.Parse)
                .ToList();

            c.Sort();

            for (var i = 0; i < c.Count() - 1; i++)
                if (c[i + 1] - c[i] != 1)
                    return false;

            return true;
        }

        private static bool IsFlush(IEnumerable<string> suits)
        {
            var distinct = suits.GroupBy(g => g)
                .Where(w => w.Count() == 5)
                .ToList();

            return distinct.Count == 1;
        }


        private static string MapRoyalToNumbers(string s)
        {
            switch (s)
            {
                case "A":
                    return s.Replace(s, "14");
                case "K":
                    return s.Replace(s, "13");
                case "Q":
                    return s.Replace(s, "12");
                case "J":
                    return s.Replace(s, "11");
                default:
                    return s;
            }
        }

        public void Show()
        {
            PokerHandRanking(new[] {"10d", "9c", "8d", "6d", "7d"});
            PokerHandRanking(new[] {"10s", "10c", "8d", "10d", "10h"});
            PokerHandRanking(new[] {"10h", "Jh", "Qh", "Ah", "Kh"});
        }
    }
}