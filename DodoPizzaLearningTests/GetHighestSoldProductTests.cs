using System;
using CSharpLearning;
using NUnit.Framework;

namespace DodoPizzaLearningTests
{
    public class GetHighestSoldProductTests
    {
        private Sale[] _sales;

        [SetUp]
        public void Setup()
        {
            _sales = new[]
            {
                new Sale()
                {
                    ProductName = "Pepperoni",
                    SaleDate = new DateTime(2019, 2, 14),
                    Amount = 9
                },
                new Sale()
                {
                    ProductName = "Margheritta",
                    SaleDate = new DateTime(2019, 2, 14),
                    Amount = 10
                },
                new Sale()
                {
                    ProductName = "Pepperoni",
                    SaleDate = new DateTime(2019, 2, 14),
                    Amount = 2
                },
                new Sale()
                {
                    ProductName = "Pepperoni",
                    SaleDate = new DateTime(2020, 5, 14),
                    Amount = 1
                },
                new Sale()
                {
                    ProductName = "Margheritta",
                    SaleDate = new DateTime(2020, 5, 14),
                    Amount = 3
                },
            };
        }

        [Test]
        [TestCase("2020-5-14", "Margheritta", 3)]
        [TestCase("2019-2-14", "Pepperoni", 11)]
        public void ShouldReturnHighestSoldProduct(DateTime salesDate, string productName, int amount)
        {
            var highestSoldProduct = LinqMethods.GetHighestSoldProduct(_sales, salesDate);
            Assert.AreEqual(productName, highestSoldProduct.ProductName);
            Assert.AreEqual(amount, highestSoldProduct.Amount);
        }

        [Test]
        [TestCase("2021-5-14", "Margheritta", 1)]
        public void ShouldReturnNull_WhenNoSalesFound(DateTime salesDate, string productName, int amount)
        {
            var highestSoldProduct = LinqMethods.GetHighestSoldProduct(_sales, salesDate);
            Assert.IsNull(highestSoldProduct);
        }
    }
}