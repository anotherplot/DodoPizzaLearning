using System;
using System.Collections.Generic;

namespace CSharpLearning
{
    public static class MyLinqExtension
    {
        public delegate bool MyWhereDelegate<in TSource>(TSource source);

        public delegate TResult MySelectDelegate<TSource, TResult>(TSource source);

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source,
            MyWhereDelegate<TSource> predicate)
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

        public static IEnumerable<TResult> MySelect<TResult, TSource>(this IEnumerable<TSource> source,
            MySelectDelegate<TSource, TResult> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (var element in source)
            {
                yield return predicate(element);
            }
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