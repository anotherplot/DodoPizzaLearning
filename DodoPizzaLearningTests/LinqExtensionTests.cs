using System;
using System.Collections.Generic;
using System.Linq;
using CSharpLearning;
using NUnit.Framework;

namespace DodoPizzaLearningTests
{
    [TestFixture]
    public class LinqExtensionTests
    {
        private List<string> _randomStrings;
        private List<DateTime> _dates;

        [SetUp]
        public void Setup()
        {
            _randomStrings = new List<string> {"one", "caterpillar", "dot", "monkey", "party", "summer"};

            _dates = new List<DateTime>
            {
                new DateTime(2020, 6, 1, 7, 47, 0),
                new DateTime(1900, 1, 12, 3, 1, 1)
            };
        }
        
        [Test]
        public void TestMyWhereWithLinq()
        {
            var result = _randomStrings.MyWhere(p => p.Length >= 6);
            var expectedResult = new List<string>() {"caterpillar", "monkey", "summer"};

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestMyWhereWithDelegate()
        {
            MyLinqExtension.MyWhereDelegate<string> del = CheckStringLength;
            var result = _randomStrings.MyWhere(del);
            var expectedResult = new List<string>() {"caterpillar", "monkey", "summer"};

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestMySelectWithDelegate()
        {
            var expectedResult = new List<string> {"Monday, 01 June 2020", "Friday, 12 January 1900"};
            MyLinqExtension.MySelectDelegate<DateTime, string> del = GetDateInLingString;
            var actualResult = _dates.MySelect(del);
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void TestMySelectWithLinq()
        {
            List<StringInfo> expectedResult = new List<StringInfo>
            {
                new StringInfo('o', 3),
                new StringInfo('c', 11),
                new StringInfo('d', 3),
                new StringInfo('m', 6),
                new StringInfo('p', 5),
                new StringInfo('s', 6),
            };
            
            List<StringInfo> result = _randomStrings.MySelect(s => new StringInfo(s[0], s.Length)).ToList();

            Assert.AreEqual(expectedResult.Count, result.Count);
            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].FirstChar, result[i].FirstChar);
                Assert.AreEqual(expectedResult[i].Length, result[i].Length);
            }
        }

        private bool CheckStringLength(string s)
        {
            return s.Length >= 6;
        }     
        private string GetDateInLingString(DateTime date)
        {
            return date.ToLongDateString();
        }
    }
}