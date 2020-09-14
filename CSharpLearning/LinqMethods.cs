using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLearning
{
    public class LinqMethods
    {
        public static IEnumerable<string> GetStringsStartingWithChar(IEnumerable<string> randomStrings, char c)
        {
            return randomStrings.Where(s => s.StartsWith(c));
        }

        public static IEnumerable<string> GetStringsWithMinLength(IEnumerable<string> randomStrings, int length)
        {
            return randomStrings.Where(s => s.Length >= length);
        }

        public static List<StringInfo> GetStringInfo(List<string> randomStrings)
        {
            return randomStrings.Select(s => new StringInfo(s[0], s.Length)).ToList();
        }

        public static IEnumerable<string> GetDatesInLongStrings(List<DateTime> dates)
        {
            return dates.Select(d => d.ToLongDateString());
        }

        public static int GetAllStringsLength(List<string> randomString)
        {
            return randomString.Aggregate(0, (result, item) => result + item.Length);
        }

        public static string GetDateTimeYearsInString(List<DateTime> dates)
        {
            return dates.Aggregate("", (result, item) => result + item.Year + ";");
        }

        public static (string Name, int Amount) GetHighestSoldProduct(IEnumerable<Sale> sales, DateTime saleDate)
        {
            var highestSoldProduct = sales.Where(sale => sale.SaleDate.Date == saleDate.Date)
                .GroupBy(sale => sale.ProductName)
                .Select(groups =>
                    new
                    {
                        ProductName = groups.Key,
                        Amount = groups.Sum(sale => sale.Amount)
                    })
                .MyMaxBy(i => i.Amount);

            return (highestSoldProduct.ProductName, highestSoldProduct.Amount);
        }
    }
}