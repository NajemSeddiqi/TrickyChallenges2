using NUnit.Framework;
using TestingStuff.Challenges;

namespace TestChallenges
{
    [TestFixture]
    public class SmoothSentenceTests
    {
        [Test]
        [TestCase("Marta appreciated deep perpendicular right trapezoids", ExpectedResult = true)]
        [TestCase("Someone is outside the doorway", ExpectedResult = false)]
        [TestCase("She eats super righteously", ExpectedResult = true)]
        [TestCase("Ben naps so often", ExpectedResult = true)]
        [TestCase("Cute triangles are cute", ExpectedResult = false)]
        [TestCase("Mad dislikes sharp pointy yoyos", ExpectedResult = true)]
        [TestCase("Rita asks Sam mean numbered dilemmas", ExpectedResult = true)]
        [TestCase("Marigold daffodils streaming happily.", ExpectedResult = false)]
        [TestCase("Simply wonderful laughing.", ExpectedResult = false)]
        public static bool IsSmooth(string sentence)
        {
            return SmoothSentences.IsSmooth(sentence);
        }
    }
}