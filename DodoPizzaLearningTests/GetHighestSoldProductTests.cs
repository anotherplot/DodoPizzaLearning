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
                new Sale()
                {
                    ProductName = "Margheritta",
                    SaleDate = new DateTime(2021, 5, 14, 1,2,1),
                    Amount = 5
                },          
                new Sale()
                {
                    ProductName = "Meats",
                    SaleDate = new DateTime(2021, 5, 14, 3,1,1),
                    Amount = 4
                },            
                new Sale()
                {
                    ProductName = "Meats",
                    SaleDate = new DateTime(2021, 5, 14, 10,1,1),
                    Amount = 3
                },
            };
        }

        [Test]
        [TestCase("2020-5-14", "Margheritta", 3)]
        [TestCase("2019-2-14", "Pepperoni", 11)]
        [TestCase("2021-5-14 11:00:21", "Meats", 7)]
        public void ShouldReturnHighestSoldProduct(DateTime salesDate, string productName, int amount)
        {
            var highestSoldProduct = LinqMethods.GetHighestSoldProduct(_sales, salesDate);
            Assert.AreEqual(productName, highestSoldProduct.Name);
            Assert.AreEqual(amount, highestSoldProduct.Amount);
        }
    }
}