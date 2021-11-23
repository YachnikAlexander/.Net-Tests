using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CustomeFormat
{
    /// <summary>
    /// Class Customer, that contains Name, Revenue and ContactPhone of every Customers
    /// </summary>
    public class Customer : IFormattable
    {
        #region Properties
        /// <summary>
        /// gets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// gets the Revenue
        /// </summary>
        public decimal Revenue { get; set; }

        /// <summary>
        /// gets the ContactPhone
        /// </summary>
        public string ContactPhone { get; set; }
        #endregion

        #region Public

        /// <summary>
        /// Cstr with 3 parametrs
        /// </summary>
        /// <param name="name">name of customer</param>
        /// <param name="revenue">revenue of customer</param>
        /// <param name="contactPhone">contactPhone of customer</param>
        /// <exception cref="ArgumentNullException">Throws if name is equal to null</exception>
        /// <exception cref="ArgumentException">throws when revenue less than 0</exception>
        /// <exception cref="ArgumentNullException">throws when contactPhone is null</exception>
        /// <exception cref="ArgumentException">throws when contactPhone didn't pass the audit of regex statement</exception>
        public Customer(string name, decimal revenue, string contactPhone)
        {
            if (name == null)
            {
                throw new ArgumentNullException($"{0} is null", nameof(name));
            }

            if (revenue < 0)
            {
                throw new ArgumentException($"{0} less than 0", nameof(revenue));
            }

            if (contactPhone == null)
            {
                throw new ArgumentNullException($"{0} is null", nameof(contactPhone));
            }

            if (ValidatePhone(contactPhone))
            {
                this.Name = String.Copy(name);
                this.Revenue = revenue;
                this.ContactPhone = String.Copy(contactPhone);
            }
            else
            {
                throw new ArgumentException($"Invalid telefon", nameof(contactPhone));
            }
        }

        #region ToString
        /// <summary>
        /// Overriding method ToString() with 0 parametrs
        /// </summary>
        /// <returns>string by format</returns>
        public override string ToString()
        {
            return this.ToString("Name_Revenue_ContactPhone", null);
        }

        /// <summary>
        /// Overriding method ToString() with 1 parametrs
        /// </summary>
        /// <param name="format">Format of string</param>
        /// <returns>string by format</returns>
        public string ToString(string format)
        {
            return this.ToString(format, null);
        }

        /// <summary>
        /// Overriding method ToString() with 2 parametrs
        /// </summary>
        /// <param name="format">format of string</param>
        /// <param name="provider">container of default Culture format</param>
        /// <returns>string by format</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "Name_Revenue_ContactPhone";
            }

            format = format.Trim();
            if (provider == null)
            {
                provider = NumberFormatInfo.CurrentInfo;
            }


            switch (format)
            {
                case "Name":
                    return this.Name.ToString(provider);
                case "Revenue":
                    return String.Format(provider, "{0,8:F}", this.Revenue);
                case "ContactPhone":
                    return this.ContactPhone.ToString(provider);
                case "Name_Revenue_ContactPhone":
                    return "Name_Revenue_ContactPhone:"
                        + this.Name.ToString(provider) + ","
                        + String.Format(provider, "{0,8:F}", this.Revenue) + ","
                        + this.ContactPhone.ToString(provider);
                case "Name_Revenue":
                    return this.Name.ToString(provider) + "," + this.Revenue.ToString(provider);
                default:
                    throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
            }
        }
        #endregion

        #endregion

        #region Private
        private bool ValidatePhone(string contactPhone)
        {
            return Regex.IsMatch(contactPhone, @"^(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", RegexOptions.IgnoreCase);
        }
        #endregion
    }

    public class CustomProvider : IFormatProvider, ICustomFormatter
    {

        IFormatProvider _parent;

        public CustomProvider() :
            this(CultureInfo.CurrentCulture)
        { }

        public CustomProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider prov)
        {
            // If it's not our format string, defer to the parent provider:
            if (arg == null || format != "Q")
            {
                return string.Format(_parent, "{0:" + format + "}", arg);
            }

            arg = arg as Customer;

            string data = string.Format(CultureInfo.InvariantCulture, "{0}", arg);
            string result = "";
            switch (format)
            {
                case "Name_Name":
                    result = string.Format(format, data); break;
            }

            return result;


        }
    }
}
