using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomialExtension
{
    public class Polinomial
    {
        #region Fields
        private readonly double[] coefs;
        private readonly int degree;
        #endregion

        #region PublicAPI
        /// <summary>
        /// Ctor for initializing polinomial by 2 arguments
        /// </summary>
        /// <param name="coefs">array of coefs</param>
        /// <param name="degree">degree of polinomial</param>
        public Polinomial(double[] coefs, int degree)
        {
            IsValid(coefs, degree);
            this.coefs = coefs;
            this.degree = degree;
        }

        /// <summary>
        /// Ctor for initializing polinomial by 1 arguments
        /// </summary>
        /// <param name="coefs">array of coefs</param>
        public Polinomial(double[] coefs)
        {
            IsValid(coefs, degree);
            int length = coefs.Length;
            this.coefs = coefs;
            this.degree = length - 1;
        }

        /// <summary>
        /// Ctor for initializing polinomial by 1 arguments
        /// </summary>
        /// <param name="degree">degree of polinomial</param>
        public Polinomial(int degree)
        {
            if (degree < 0)
            {
                throw new ArgumentException(nameof(degree));
            }

            List<double> arr = new List<double>();

            for (int i = 0; i < degree + 1; i++)
            {
                arr.Add(1);
            }

            this.degree = degree;
            this.coefs = arr.ToArray();
        }

        /// <summary>
        /// Ctor for initializing polinomial by default value
        /// </summary>
        public Polinomial()
        {
            this.coefs = new double[] { 1, 1, 1 };
            this.degree = 2;
        }

        /// <summary>
        /// method for getting coefficients of polinomial
        /// </summary>
        /// <returns>array of coef</returns>
        public double[] getCoef()
        {
            return coefs;
        }

        /// <summary>
        /// method for getting degree of polinomial
        /// </summary>
        /// <returns>degree of polinomial</returns>
        public int getDegree()
        {
            return degree;
        }

        /// <summary>
        /// Overriding method Equals of 2 object
        /// </summary>
        /// <param name="obj">object whith which compare</param>
        /// <returns>bool value of equity of polinomials</returns>
        /// <exception cref="ArgumentNullException">if the object null</exception>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            Polinomial polin = obj as Polinomial;

            return this == polin;
        }

        /// <summary>
        /// Overriding method GetHashCode of  object
        /// </summary>
        /// <returns>hash code of object</returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < this.coefs.Length; i++)
            {
                hashCode += (int)(this.coefs[i] * Math.Pow(this.coefs[i], this.degree));
            }
            return hashCode;
        }

        /// <summary>
        /// overloading operator + for normal addition of 2 polinomial
        /// </summary>
        /// <param name="p1">first polinomial in sum</param>
        /// <param name="p2">second polinomial in sum</param>
        /// <returns>Sum Polinomial</returns>
        public static Polinomial operator +(Polinomial p1, Polinomial p2)
        {
            List<double> newCoef = new List<double>();
            int maxDegree = (p1.degree > p2.degree) ? p1.degree : p2.degree;


            int lenP1 = p1.coefs.Length;
            int lenP2 = p2.coefs.Length;

            for (int i = 0; i < maxDegree; i++)
            {
                if (i < lenP1 && i < lenP2)
                {
                    newCoef.Add(p1.coefs[i] + p2.coefs[i]);
                }

                if (i >= lenP1)
                {
                    newCoef.Add(0 + p2.coefs[i]);
                }

                if (i >= lenP2)
                {
                    newCoef.Add(p1.coefs[i] + 0);
                }
            }

            Polinomial newPol = new Polinomial(newCoef.ToArray(), maxDegree);

            return newPol;
        }

        /// <summary>
        /// overloading operator - for normal subtraction of 2 polinomial
        /// </summary>
        /// <param name="p1">first polinomial in subtraction</param>
        /// <param name="p2">second polinomial in subtraction</param>
        /// <returns>Subtraction Polinomial</returns>
        public static Polinomial operator -(Polinomial p1, Polinomial p2)
        {
            List<double> newCoef = new List<double>();
            int maxDegree = (p1.degree > p2.degree) ? p1.degree : p2.degree;


            int lenP1 = p1.coefs.Length;
            int lenP2 = p2.coefs.Length;

            for (int i = 0; i < maxDegree; i++)
            {
                if (i < lenP1 && i < lenP2)
                {
                    newCoef.Add(p1.coefs[i] - p2.coefs[i]);
                }

                if (i >= lenP1)
                {
                    newCoef.Add(0 - p2.coefs[i]);
                }

                if (i >= lenP2)
                {
                    newCoef.Add(p1.coefs[i] - 0);
                }
            }

            Polinomial newPol = new Polinomial(newCoef.ToArray(), maxDegree);

            return newPol;
        }

        /// <summary>
        /// overloading operator * for normal multiplying of 2 polinomial
        /// </summary>
        /// <param name="p1">first polinomial in multiplying</param>
        /// <param name="p2">second polinomial in multiplying</param>
        /// <returns>multiplying Polinomial</returns>
        public static Polinomial operator *(Polinomial p1, Polinomial p2)
        {
            int maxDegree = p1.getDegree() + p2.getDegree();
            double[] coefP3 = new double[maxDegree + 1];

            for (int i = p1.getDegree(); i >= 0; i--)
            {
                for (int j = p2.getDegree(); j >= 0; j--)
                {
                    coefP3[i + j] += p1.getCoef()[i] * p2.getCoef()[j];
                }
            }

            Polinomial p3 = new Polinomial(coefP3, maxDegree);

            return p3;
        }

        /// <summary>
        /// overloading operator != for compare unequity of 2 2 polinomial
        /// </summary>
        /// <param name="p1">first polinomial in comparing</param>
        /// <param name="p2">second polinomial in comparing</param>
        /// <returns>bool value of the unequity</returns>
        public static bool operator !=(Polinomial p1, Polinomial p2)
        {
            if (p1.getDegree() == p2.getDegree())
            {
                for (int i = 0; i < p1.getCoef().Length; i++)
                {
                    if (p1.getCoef()[i] != p2.getCoef()[i])
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// overloading operator == for compare equity of 2 2 polinomial
        /// </summary>
        /// <param name="p1">first polinomial in comparing</param>
        /// <param name="p2">second polinomial in comparing</param>
        /// <returns>bool value of the equity</returns>
        public static bool operator ==(Polinomial p1, Polinomial p2)
        {
            if (p1.getDegree() == p2.getDegree())
            {
                for (int i = 0; i < p1.getCoef().Length; i++)
                {
                    if (p1.getCoef()[i] != p2.getCoef()[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Overriding method for convert polinomial to string
        /// </summary>
        /// <returns>string presentation of polinomial</returns>
        public override string ToString()
        {
            StringBuilder polinom = new StringBuilder();
            for (int i = 0; i <= this.getDegree(); i++)
            {
                StringBuilder onePol = new StringBuilder();
                if (this.getDegree() - i == 0)
                {
                    polinom.Append(this.getCoef()[i]);
                }
                else
                {
                    if (this.getCoef()[i] == 0)
                    {
                        polinom.Append("");
                    }
                    else
                    {
                        if (this.getDegree() - i == 1)
                        {
                            if (this.getCoef()[i] == 1)
                            {
                                polinom.Append("X + ");
                            }
                            else
                            {
                                polinom.Append(this.getCoef()[i] + "X + ");
                            }
                        }
                        else
                        {
                            polinom.Append(this.getCoef()[i] + "X^" + (this.getDegree() - i) + " + ");
                        }
                    }
                }
            }
            return polinom.ToString();
        }

        #endregion

        #region Private
        private void IsValid(double[] coefs, int degree = 1)
        {
            if (coefs == null)
            {
                throw new ArgumentNullException(nameof(coefs));
            }

            if (degree < 0)
            {
                throw new ArgumentException(nameof(degree));
            }
        }
        #endregion
    }
}
