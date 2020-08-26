using System;
using System.Collections.Generic;
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
            MyLinqExtension.MyAggregateDelegate<string> del = CheckStringLength;
            var result = _randomStrings.MyWhere(del);
            var expectedResult = new List<string>() {"caterpillar", "monkey", "summer"};

            Assert.AreEqual(expectedResult, result);
        }

        private bool CheckStringLength(string s)
        {
            return s.Length >= 6;
        }
    }
}