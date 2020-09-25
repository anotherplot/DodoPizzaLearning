using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLearning
{
    public class FraudOrderCalculation
    {
        public static IEnumerable<Order> GetFraudOrdersWithFor(IEnumerable<Order> allOrders, TimeSpan minCookingTime,
            TimeSpan minTotalTime, TimeSpan maxTotalTime)
        {
            var fraudOrders = new List<Order>();
            foreach (var order in allOrders)
            {
                var hasCookingTimeFraud = false;
                var maxGivenOutTime = DateTime.MinValue;
                foreach (var product in order.Products)
                {
                    var productCookingTime = product.PackedAt - product.StartedCookingAt;
                    if (productCookingTime < minCookingTime)
                    {
                        hasCookingTimeFraud = true;
                    }

                    if (product.GivenOutAt > maxGivenOutTime)
                    {
                        maxGivenOutTime = product.GivenOutAt;
                    }
                }

                var orderTotalTime = maxGivenOutTime - order.QueuedAt;
                var hasTotalTimeFraud = orderTotalTime > maxTotalTime || orderTotalTime < minTotalTime;
                if (hasCookingTimeFraud || hasTotalTimeFraud)
                {
                    fraudOrders.Add(order);
                }
            }

            return fraudOrders;
        }

        public static IEnumerable<Order> GetFraudOrders(IEnumerable<Order> allOrders, TimeSpan minCookingTime,
            TimeSpan minTotalTime, TimeSpan maxTotalTime)
        {
            var fraudOrders = allOrders.Where(o =>
            {
                var orderTotalTime = o.Products.Max(p => p.GivenOutAt) - o.QueuedAt;
                return o.Products.Any(p => p.PackedAt - p.StartedCookingAt < minCookingTime)
                       || orderTotalTime  > maxTotalTime
                           || orderTotalTime < minTotalTime;
            });
            return fraudOrders;
        }
    }
}