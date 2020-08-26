using System;
using System.Collections.Generic;

namespace CSharpLearning
{
    public static class MyLinqExtension
    {
        public delegate bool MyAggregateDelegate<TSource>(TSource source);

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source,
            MyAggregateDelegate<TSource> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var resultList = new List<TSource>();
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    resultList.Add(element);
                }
            }

            return resultList;
        }


        static IEnumerable<TSource> MyWhereUsingYield<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (TSource element in source)
            {
                if (predicate(element))
                    yield return element;
            }
        }
    }
}