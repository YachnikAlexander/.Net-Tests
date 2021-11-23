using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitInsert.Test
{
    [TestClass]
    public class BitInsertTests
    {
        [TestMethod]
        public void BitInsertRange0to0fristTest()
        {
            int firstNumber = 8;
            int secondNumber = 15;
            int extend = 9;
            int i = 0;
            int j = 0;

            int actual = InsertBitNumber.BitInsert.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod]
        public void BitInsertRange0to0secondTest()
        {
            int firstNumber = 15;
            int secondNumber = 15;
            int extend = 15;
            int i = 0;
            int j = 0;

            int actual = InsertBitNumber.BitInsert.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod]
        public void BitInsertRangeThirdTest()
        {
            int firstNumber = 12;
            int secondNumber = 14;
            int extend = 60;
            int i = 2;
            int j = 8;

            int actual = InsertBitNumber.BitInsert.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod]
        public void BitInsertRangeForthTest()
        {
            int firstNumber = 8;
            int secondNumber = 15;
            int extend = 120;
            int i = 3;
            int j = 8;

            int actual = InsertBitNumber.BitInsert.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod]
        public void BitInsertRangeFifthTest()
        {
            int firstNumber = 100;
            int secondNumber = 73;
            int extend = 299008;
            int i = 12;
            int j = 26;

            int actual = InsertBitNumber.BitInsert.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod]
        public void BitInsertRangeSixsTest()
        {
            int firstNumber = 34;
            int secondNumber = 22;
            int extend = 5632;
            int i = 8;
            int j = 13;

            int actual = InsertBitNumber.BitInsert.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberArgumentsOutOfRange()
        {
            int firstNumber = 15;
            int secondNumber = 15;
            int i = 2;
            int j = 38;

            int actual = InsertBitNumber.BitInsert.InsertNumber(firstNumber, secondNumber, i, j);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void InsertNumberJIsLessI()
        {
            int firstNumber = 15;
            int secondNumber = 15;
            int i = 5;
            int j = 1;

            int actual = InsertBitNumber.BitInsert.InsertNumber(firstNumber, secondNumber, i, j);
        }
    }
}
