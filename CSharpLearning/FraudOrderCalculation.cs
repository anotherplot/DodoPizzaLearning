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
            
            var fraudOrders = allOrders
                .Select(o => new {
                    Order = o,
                    LastProductGivenOutTime = o.Products.Max(p => p.GivenOutAt),
                    ProductCookingTimes = o.Products.Select(p => p.PackedAt - p.StartedCookingAt),
                    
                })
                .Select(x => new {
                    x.Order,
                    TotalTime = x.LastProductGivenOutTime - x.Order.QueuedAt,
                    FastestProductCookingTime = x.ProductCookingTimes.Min()
                })
                .Select(x => new {
                    x.Order,
                    HasTotalTimeFraud = x.TotalTime < minTotalTime || x.TotalTime > maxTotalTime,
                    HasCookingTimeFraud = x.FastestProductCookingTime < minCookingTime,
                })
                .Where(x => x.HasCookingTimeFraud || x.HasTotalTimeFraud)
                .Select(x => x.Order);
            return fraudOrders;
        }
    }
}