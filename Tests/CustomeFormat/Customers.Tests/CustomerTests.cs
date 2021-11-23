using System;
using NUnit.Framework;
using CustomeFormat;

namespace Customers.Tests
{
    [TestFixture]
    public class CusomerTests
    {
        [TestCase("Sasha Yachnik", 100000, "8578399", ExpectedResult = "Name_Revenue_ContactPhone:Sasha Yachnik,100000.00,8578399")]
        public string Customer_Name_Revenue_ContactPhone_CustomProvider_Tests(string name, decimal revenue, string contactPhone)
        {
            Customer temp = new Customer(name, revenue, contactPhone);

            return temp.ToString("Name_Revenue_ContactPhone", new CustomProvider());
        }

        [TestCase("Sasha Yachnik", 100000, "8578399", "Name", ExpectedResult = "Sasha Yachnik")]
        [TestCase("Sasha Yachnik", 100000, "8578399", "Revenue", ExpectedResult = "100000.00")]
        [TestCase("Sasha Yachnik", 100000, "8578399", "ContactPhone", ExpectedResult = "8578399")]
        [TestCase("Sasha Yachnik", 100000, "8578399", "Name_Revenue", ExpectedResult = "Sasha Yachnik,100000")]
        public string Customer_ContactPhone_Tests(string name, decimal revenue, string contactPhone, string format)
        {
            Customer temp = new Customer(name, revenue, contactPhone);

            return temp.ToString(format);
        }

        [TestCase(null, 16, "8578399")]
        [TestCase("sasha", 16, null)]
        public void Customer_ArgumentNullException_Tests(string name, decimal revenue, string contactPhone)
        {
            Assert.Throws<ArgumentNullException>(() => new Customer(name, revenue, contactPhone));
        }

        [TestCase("sasha", -16, "8578399")]
        [TestCase("sasha", 16, "+67678300")]
        public void Customer_ArgumentException_Tests(string name, decimal revenue, string contactPhone)
        {
            Assert.Throws<ArgumentException>(() => new Customer(name, revenue, contactPhone));
        }
    }
}
