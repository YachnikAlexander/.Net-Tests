using System;
using ConvertStringToNumber;
using NUnit.Framework;

namespace ConvertStringTests
{
    [TestFixture]
    public class ConvertStringToNumberTests
    {
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]
        public int ConvertStringToNumberTest(string number, int _base)
        {
            return number.StringToInt(_base);
        }

        [TestCase("764241", 20)]
        [TestCase("SA123", 2)]
        [TestCase("1AeF101", 2)]
        public void Converting_ArgumentException(string number, int _base)
        {
            Assert.Throws<ArgumentException>(() => number.StringToInt(_base));
        }

        [TestCase("11111111111111111111111111111111", 2)]
        [TestCase("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", 16)]
        [TestCase("777777777777777777777777777", 8)]
        [TestCase("BBBBBBBBBBBBBBBBBB", 12)]
        public void Converting_OverflowException(string number, int _base)
        {
            Assert.Throws<OverflowException>(() => number.StringToInt(_base));
        }

        [TestCase(null, 16)]
        public void Converting_ArgumentNullException(string number, int _base)
        {
            Assert.Throws<ArgumentNullException>(() => number.StringToInt(_base));
        }
    }
}
