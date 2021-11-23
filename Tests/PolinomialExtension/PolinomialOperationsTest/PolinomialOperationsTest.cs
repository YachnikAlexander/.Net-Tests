using PolinomialExtension;
using NUnit.Framework;
using System;

namespace Polynomial.Tests
{
    [TestFixture]
    public class PolinomialOperationsTest
    {
        [TestCase(new double[] { 1, 2, 3 }, 2, ExpectedResult = true)]
        [TestCase(new double[] { 1, 4, 8 }, 2, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3, 4 }, 3, ExpectedResult = false)]
        public bool PolinomialEqualsTests(double[] coefs, int degree)
        {
            Polinomial firstPol = new Polinomial(new double[] { 1, 2, 3 }, 2);
            Polinomial secondPol = new Polinomial(coefs, degree);

            return firstPol.Equals(secondPol);
        }

        [TestCase(new double[] { 1, 2, 3 }, 2, ExpectedResult = 36)]
        [TestCase(new double[] { 1, 4, 8 }, 2, ExpectedResult = 577)]
        [TestCase(new double[] { 1, 2, 3, 4 }, 3, ExpectedResult = 354)]
        public int PolinomialHashCodeTests(double[] coefs, int degree)
        {
            Polinomial Pol = new Polinomial(coefs, degree);

            return Pol.GetHashCode();
        }

        [TestCase(new double[] { 1, 2, 3.5 }, 2, new double[] { 2, 4, 6.5 }, 2)]
        [TestCase(new double[] { 1, 2, 3, 4.8 }, 3, new double[] { 2, 4, 6, 4.8 }, 3)]
        public void PolinomialSumTests(double[] coefs, int degree, double[] sumCoef, int sumDegree)
        {

            Polinomial firstPol = new Polinomial(new double[] { 1, 2, 3 }, 2);
            Polinomial secondPol = new Polinomial(coefs, degree);

            Polinomial sumPol = firstPol + secondPol;
            Assert.AreEqual(sumPol.getDegree(), sumDegree);

            for (int i = 0; i < sumPol.getCoef().Length; i++)
            {
                Assert.AreEqual(sumPol.getCoef()[i], sumCoef[i], 0.1);
            }
        }

        [TestCase(new double[] { 1, 7, 3.5 }, 2, new double[] { 0, 5, 0.5 }, 2)]
        [TestCase(new double[] { 1, 1.8, -10, 4.8 }, 3, new double[] { 0, -0.2, -13, 4.8 }, 3)]
        public void PolinomialSubtractionTests(double[] coefs, int degree, double[] sumCoef, int sumDegree)
        {

            Polinomial firstPol = new Polinomial(new double[] { 1, 2, 3 }, 2);
            Polinomial secondPol = new Polinomial(coefs, degree);

            Polinomial sumPol = secondPol - firstPol;
            Assert.AreEqual(sumPol.getDegree(), sumDegree);

            for (int i = 0; i < sumPol.getCoef().Length; i++)
            {
                Assert.AreEqual(sumPol.getCoef()[i], sumCoef[i], 0.1);
            }
        }

        [TestCase(new double[] { 1, 7, 4 }, 2, new double[] { 1, 9, 21, 29, 12 }, 4)]
        [TestCase(new double[] { 1, 7, 3, 5, 8 }, 4, new double[] { 1, 9, 20, 32, 27, 31, 24 }, 6)]
        public void PolinomialMultiplicationTests(double[] coefs, int degree, double[] sumCoef, int sumDegree)
        {

            Polinomial firstPol = new Polinomial(new double[] { 1, 2, 3 }, 2);
            Polinomial secondPol = new Polinomial(coefs, degree);

            Polinomial sumPol = firstPol * secondPol;
            Assert.AreEqual(sumPol.getDegree(), sumDegree);

            for (int i = 0; i < sumPol.getCoef().Length; i++)
            {
                Assert.AreEqual(sumPol.getCoef()[i], sumCoef[i], 0.1);
            }
        }

        [TestCase(new double[] { 1, 7, 4 }, 2, new double[] { 1, 7, 4 }, 2, ExpectedResult = true)]
        [TestCase(new double[] { 1, 7, 3, 5, 9 }, 4, new double[] { 1, 7, 3, 5, 8 }, 4, ExpectedResult = false)]
        public bool PolinomialEquityTests(double[] coefs1, int degree1, double[] coefs2, int degree2)
        {
            Polinomial firstPol = new Polinomial(coefs1, degree1);
            Polinomial secondPol = new Polinomial(coefs2, degree2);
            return firstPol == secondPol;
        }

        [TestCase(new double[] { 1, 7, 4, 5 }, 3, new double[] { 1, 7, 4 }, 2, ExpectedResult = true)]
        [TestCase(new double[] { 1, 7, 3, 5, 8 }, 4, new double[] { 1, 7, 3, 5, 8 }, 4, ExpectedResult = false)]
        public bool PolinomialUnequityTests(double[] coefs1, int degree1, double[] coefs2, int degree2)
        {
            Polinomial firstPol = new Polinomial(coefs1, degree1);
            Polinomial secondPol = new Polinomial(coefs2, degree2);
            return firstPol != secondPol;
        }

        [TestCase(new double[] { 1, 7, 4, 1 }, 3, ExpectedResult = "1X^3 + 7X^2 + 4X + 1")]
        public string PolinomialToStringTests(double[] coefs1, int degree1)
        {
            Polinomial firstPol = new Polinomial(coefs1, degree1);
            return firstPol.ToString();
        }

    }
}
