using NUnit.Framework;
using TestingStuff.Challenges;

namespace TestChallenges
{
    [TestFixture]
    public class AbacusTests
    {
        [TestCase(new string[] {"|O|O|O|", "O|O|O|O", "-------", "||O|OO|", "OOOO||O", "OO|OOOO", "OOOOOOO", "OOOOOOO"},
            0, ExpectedResult = 5070615)]
        [TestCase(new string[] {"OOO||OO", "|||OO||", "-------", "OOOOO||", "OOO||OO", "OO|OOOO", "OOOOOOO", "||OOOOO"},
            0, ExpectedResult = 4426600)]
        [TestCase(new string[] {"|O|O|OO", "O|O|O||", "-------", "OO||||O", "O|OOOOO", "|OOOOOO", "OOOOOO|", "OOOOOOO"},
            0, ExpectedResult = 7150503)]
        [TestCase(new string[] {"|OOO|OO", "O|||O||", "-------", "|||OO|O", "OOOO|OO", "OOO|OOO", "OOOOOOO", "OOOOOO|"},
            0, ExpectedResult = 5002604)]
        [TestCase(new string[] {"O|OOO|O", "|O|||O|", "-------", "OOO|OO|", "|OOOOOO", "OO|OOOO", "O|OOO|O", "OOOO|OO"},
            0, ExpectedResult = 1820480)]
        [TestCase(new string[] {"OOO|OO|", "|||O||O", "-------", "OOOOO|O", "|OOO|O|", "OO|OOOO", "OOO|OOO", "O|OOOOO"},
            0, ExpectedResult = 1428106)]
        [TestCase(new string[] {"OOOOOOO", "|||||||", "-------", "||OO|OO", "OO|OO|O", "OOOOOOO", "OOO|OOO", "OOOOOO|"},
            0, ExpectedResult = 13014)]
        [TestCase(new string[] {"|OOO|||", "O|||OOO", "-------", "O||OOOO", "OOOOOOO", "OOOOO|O", "|OO||O|", "OOOOOOO"},
            0, ExpectedResult = 8003878)]
        [TestCase(new string[] {"O|OOOOO", "|O|||||", "-------", "||OO|||", "OOOOOOO", "OOOOOOO", "OO|OOOO", "OOO|OOO"},
            0, ExpectedResult = 534000)]
        [TestCase(new string[] {"OOOO|||", "||||OOO", "-------", "|OO||OO", "OOOOOOO", "OOOOOO|", "OO|OO|O", "O|OOOOO"},
            0, ExpectedResult = 430587)]
        [TestCase(new string[] {"OOO|||O", "|||OOO|", "-------", "||OOOO|", "OOOOOOO", "OOOOO|O", "OO|OOOO", "OOO||OO"},
            0, ExpectedResult = 39970)]
        [TestCase(new string[] {"O||OO||", "|OO||OO", "-------", "OO|OOO|", "O|OOOOO", "OOOOOOO", "OOOO|OO", "|OO|O|O"},
            0, ExpectedResult = 4654395)]
        [TestCase(new string[] {"OOO|OO|", "|||O||O", "-------", "|||OO||", "OOOOOOO", "OOO|OOO", "OOOOOOO", "OOOO|OO"},
            0, ExpectedResult = 7405)]
        [TestCase(new string[] {"|O|OOOO", "O|O||||", "-------", "OO|OO|O", "|OOOOOO", "OOO||OO", "OOOOOOO", "O|OOOO|"},
            0, ExpectedResult = 6452204)]
        [TestCase(new string[] {"O|OO|O|", "|O||O|O", "-------", "OOOOO|O", "OOOOOO|", "||O||OO", "OOOOOOO", "OO|OOOO"},
            0, ExpectedResult = 2742706)]
        [TestCase(new string[] {"OO|OOOO", "||O||||", "-------", "OO|O|||", "OOOOOOO", "O|OOOOO", "OOOOOOO", "|OO|OOO"},
            0, ExpectedResult = 4254000)]
        [TestCase(new string[] {"|OOOOO|", "O|||||O", "-------", "OOOOO|O", "O|OOOO|", "|OOOOOO", "OOOO|OO", "OO||OOO"},
            0, ExpectedResult = 7144306)]
        [TestCase(new string[] {"OO|OO||", "||O||OO", "-------", "O|||O|O", "OOOOOOO", "|OOOOOO", "OOOO|O|", "OOOOOOO"},
            0, ExpectedResult = 2050358)]
        [TestCase(new string[] {"||O|OOO", "OO|O|||", "-------", "O||||OO", "|OOOOOO", "OOOOOO|", "OOOOO|O", "OOOOOOO"},
            0, ExpectedResult = 6505032)]
        [TestCase(new string[] {"|OOOO|O", "O||||O|", "-------", "|O||OO|", "OOOOOOO", "O|OOOOO", "OOOOOOO", "OOOO||O"},
            0, ExpectedResult = 5200490)]
        public static int TestSoroban(string[] frame, int test)
        {
            return Abacus.Soroban(frame);
        }
    }
}