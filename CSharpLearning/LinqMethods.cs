using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLearning
{
    public class LinqMethods
    {
        public static IEnumerable<string> StartsWithChar(List<string> randomStrings, char c)
        {
            return randomStrings.Where(_ => _.StartsWith(Char.ToLower(c)));
        }

        public static IEnumerable<string> StringsWithLength(List<string> randomString, int length)
        {
            return randomString.Where(_ => _.Length == length);
        }

        public static List<StringInfo> SelectStartCharWithStringLength(List<string> randomString)
        {
            return randomString.Select(s => new StringInfo(s[0], s.Length)).ToList();
        }

        public static int GetAllStringsLength(List<string> randomString)
        {
            return randomString.Aggregate(0, (result, item) => result + item.Length);
        }

    }
}