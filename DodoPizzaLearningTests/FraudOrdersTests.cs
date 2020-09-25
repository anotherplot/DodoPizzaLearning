using System;
using System.Collections.Generic;
using System.Linq;
using CSharpLearning;
using NUnit.Framework;

namespace DodoPizzaLearningTests
{
    public class FraudOrdersTests
    {
        private List<Order> _orders = new List<Order>();

        [SetUp]
        public void Setup()
        {
           var product1 = new Product()
            {
                StartedCookingAt = new DateTime(2020,09,25,10,2,0),
                PackedAt = new DateTime(2020,09,25,10,6,0),
                GivenOutAt = new DateTime(2020,09,25,10,15,0)
            };             
            var product2 = new Product()
            {
                StartedCookingAt = new DateTime(2020,09,25,10,1,0),
                PackedAt = new DateTime(2020,09,25,10,7,0),
                GivenOutAt = new DateTime(2020,09,25,10,7,0)
            };          
            var product3 = new Product()
            {
                StartedCookingAt = new DateTime(2020,09,25,10,2,0),
                PackedAt = new DateTime(2020,09,25,10,10,0),
                GivenOutAt = new DateTime(2020,09,25,10,20,0)
            };        
            var product4 = new Product()
            {
                StartedCookingAt = new DateTime(2020,09,25,10,1,0),
                PackedAt = new DateTime(2020,09,25,10,8,0),
                GivenOutAt = new DateTime(2020,09,25,10,15,0)
            };       
            
            var product5 = new Product()
            {
                StartedCookingAt = new DateTime(2020,09,25,10,0,0),
                PackedAt = new DateTime(2020,09,25,10,5,0),
                GivenOutAt = new DateTime(2020,09,25,10,7,0)
            };

            _orders.Add(new Order()
            {
                Products = new List<Product> {product1, product4},
                QueuedAt = new DateTime(2020, 09, 25, 10, 0, 0)

            });
            _orders.Add(new Order()
            {
                Products = new List<Product> {product2, product5},
                QueuedAt = new DateTime(2020, 09, 25, 10, 0, 0)

            });
            _orders.Add(new Order()
            {
                Products = new List<Product> {product3, product4},
                QueuedAt = new DateTime(2020, 09, 25, 10, 0, 0)

            });
            _orders.Add( new Order()
            {
                Products = new List<Product>{product4},
                QueuedAt = new DateTime(2020,09,25,10,0,0)
                
            });
        }

        [Test]
        public void GetFraudOrders()
        {
            var fraudOrders = FraudOrderCalculation.GetFraudOrders(_orders,
                TimeSpan.FromMinutes(5), 
                TimeSpan.FromMinutes(8),
                TimeSpan.FromMinutes(15)).ToList();

            var expectedFraudOrders = new List<Order>{
                _orders.ElementAt(0),
                _orders.ElementAt(1),
                _orders.ElementAt(2)};

            Assert.AreEqual(expectedFraudOrders,fraudOrders);
        }
    }
}