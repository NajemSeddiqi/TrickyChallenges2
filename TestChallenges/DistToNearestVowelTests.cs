using NUnit.Framework;
using TestingStuff.Challenges;

namespace TestChallenges
{
    [TestFixture]
    public class DistToNearestVowelTests
    {
        [Test]
        [TestCase("aaaaa", ExpectedResult = new int[] {0, 0, 0, 0, 0})]
        [TestCase("bba", ExpectedResult = new int[] {2, 1, 0})]
        [TestCase("abbb", ExpectedResult = new int[] {0, 1, 2, 3})]
        [TestCase("abab", ExpectedResult = new int[] {0, 1, 0, 1})]
        [TestCase("babbb", ExpectedResult = new int[] {1, 0, 1, 2, 3})]
        [TestCase("baaab", ExpectedResult = new int[] {1, 0, 0, 0, 1})]
        [TestCase("abcdabcd", ExpectedResult = new int[] {0, 1, 2, 1, 0, 1, 2, 3})]
        [TestCase("abbaaaaba", ExpectedResult = new int[] {0, 1, 1, 0, 0, 0, 0, 1, 0})]
        [TestCase("treesandflowers", ExpectedResult = new int[] {2, 1, 0, 0, 1, 0, 1, 2, 2, 1, 0, 1, 0, 1, 2})]
        [TestCase("pokerface", ExpectedResult = new int[] {1, 0, 1, 0, 1, 1, 0, 1, 0})]
        [TestCase("beautiful", ExpectedResult = new int[] {1, 0, 0, 0, 1, 0, 1, 0, 1})]
        [TestCase("rythmandblues", ExpectedResult = new int[] {5, 4, 3, 2, 1, 0, 1, 2, 2, 1, 0, 0, 1})]
        [TestCase("shopper", ExpectedResult = new int[] {2, 1, 0, 1, 1, 0, 1})]
        [TestCase("singingintherain", ExpectedResult = new int[] {1, 0, 1, 1, 0, 1, 1, 0, 1, 2, 1, 0, 1, 0, 0, 1})]
        [TestCase("sugarandspice", ExpectedResult = new int[] {1, 0, 1, 0, 1, 0, 1, 2, 2, 1, 0, 1, 0})]
        [TestCase("totally", ExpectedResult = new int[] {1, 0, 1, 0, 1, 2, 3})]
        public int[] TestVowelDistances(string text)
        {
            return DistToNearestVowel.DistanceToNearestVowel(text);
        }
    }
}