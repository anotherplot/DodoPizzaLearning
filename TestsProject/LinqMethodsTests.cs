using System.Collections.Generic;
using CSharpLearning;
using NUnit.Framework;

namespace TestsProject
{
    public class LinqMethodsTests
    {
        private List<string> randomStrings;

        [SetUp]
        public void Setup()
        {
            randomStrings = new List<string>();
            randomStrings.Add("one");
            randomStrings.Add("caterpillar");
            randomStrings.Add("dot");
        }

        [Test]
        [TestCase('d', "dot")]
        [TestCase('O', "one")]
        public void ListContainsStringsStartingWithChar(char c, string word)
        {
            var result = LinqMethods.StartsWithChar(randomStrings, c);
            Assert.AreEqual(new List<string>() {word}, result);
        }

        [Test]
        public void ReturnStringsWithLength()
        {
            var result = LinqMethods.StringsWithLength(randomStrings, 3);
            Assert.AreEqual(new List<string>() {"one", "dot"}, result);
        }

        [Test]
        public void GetCorrectStringInfoFromList()
        {
            var actual = LinqMethods.SelectStartCharWithStringLength(randomStrings);
            List<StringInfo> expected = new List<StringInfo>
            {
                new StringInfo('o', 3),
                new StringInfo('c', 11),
                new StringInfo('d', 3),
            };
            Assert.AreEqual(expected.Count, actual.Count);

            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].FirstChar, actual[i].FirstChar);
                Assert.AreEqual(expected[i].Length, actual[i].Length);
            }
        }

        [Test]
        public void CheckAllStringsLength()
        {
            var result = LinqMethods.GetAllStringsLength(randomStrings);

            Assert.AreEqual(17, result);
        }
    }
}