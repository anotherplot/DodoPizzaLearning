using System;
using System.Collections.Generic;
using CSharpLearning;
using NUnit.Framework;

namespace DodoPizzaLearningTests
{
    [TestFixture]
    public class LinqTests
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
        [TestCase('d', "dot")]
        [TestCase('m', "monkey")]
        public void ListContainsStringsStartingWithChar(char c, string word)
        {
            var result = LinqMethods.GetStringsStartingWithChar(_randomStrings, c);
            var expectedResult = new List<string>() {word};

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ReturnStringsWithLength()
        {
            var result = LinqMethods.GetStringsWithMinLength(_randomStrings, 6);
            var expectedResult = new List<string>() {"caterpillar", "monkey", "summer"};

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetCorrectStringInfoFromList()
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
            var result = LinqMethods.GetStringInfo(_randomStrings);

            Assert.AreEqual(expectedResult.Count, result.Count);
            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].FirstChar, result[i].FirstChar);
                Assert.AreEqual(expectedResult[i].Length, result[i].Length);
            }
        }

        [Test]
        public void CheckAllStringsLength()
        {
            var expectedResult = 34;
            var result = LinqMethods.GetAllStringsLength(_randomStrings);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CheckGetDatesInLongStrings()
        {
            var expectedResult = new List<string> {"Monday, 01 June 2020", "Friday, 12 January 1900"};
            var result = LinqMethods.GetDatesInLongStrings(_dates);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CheckGetDateTimeYearsInString()
        {
            var expectedResult = "2020;1900;";
            var result = LinqMethods.GetDateTimeYearsInString(_dates);

            Assert.AreEqual(expectedResult, result);
        }
    }
}