using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindNumber;

namespace FindNumberTests
{
    [TestClass]
    public class FindNextBiggerTests
    {
        [TestMethod]
        public void FindNextBiggerOf_12()
        {
            int number = 12;
            int expected = 21;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_513()
        {
            int number = 513;
            int expected = 531;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_2018()
        {
            int number = 2018;
            int expected = 2081;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_1234321()
        {
            int number = 1234321;
            int expected = 1241233;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_1234126()
        {
            int number = 1234126;
            int expected = 1234162;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_3456432()
        {
            int number = 3456432;
            int expected = 3462345;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_10()
        {
            int number = 10;
            int expected = -1;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_20()
        {
            int number = 10;
            int expected = -1;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_414()
        {
            int number = 414;
            int expected = 441;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerOf_144()
        {
            int number = 144;
            int expected = 414;

            int actual = FindNumberService.FindBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNextBiggerOf_Minus10_ArgumentException()
        {
            int number = -10;

            int actual = FindNumberService.FindBiggerNumber(number);
        }
    }
}
