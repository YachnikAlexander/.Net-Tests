using System;
using NUnit.Framework;
using FindingNRoot;
using Assert = NUnit.Framework.Assert;

namespace NunitTests
{
    [TestFixture]
    public class NewtonMethodTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        public void FindNRoot_Number_Degree_Accuracy(double number, int degree, double accuracy, double expected)
        {
            Assert.AreEqual(RootNDegree.NewtonNRoot(number, degree, accuracy), expected, accuracy);
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindingNRoot_Number_Degree_Accuracy_ArgumentOutOfRangeException(double number, int degree,
            double accuracy)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RootNDegree.NewtonNRoot(number, degree, accuracy));
        }
    }
}
