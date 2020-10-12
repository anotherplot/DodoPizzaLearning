using System;
using System.Collections.Generic;

namespace CSharpLearning
{
    public class Order
    {
        public Order()
        {
        }

        public List<Product> Products { get; set; }
        public DateTime QueuedAt { get; set; }
    }

    public class Product
    {
        public DateTime StartedCookingAt { get; set; }
        public DateTime PackedAt { get; set; }
        public DateTime GivenOutAt { get; set; }

        public Product()
        {
        }
    }
}