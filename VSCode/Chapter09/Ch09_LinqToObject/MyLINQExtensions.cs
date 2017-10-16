using System.Collections.Generic;

namespace System.Linq
{
    public static class MyLINQExtensions
    {
        // 연결할 수 있는 LINQ 확장 메서드
        public static IEnumerable<T> ProcessSequence<T>(
        this IEnumerable<T> sequence)
        {
            return sequence;
        }

        // 스칼라 LINQ 확장 메서드
        public static long SummariseSequence<T>(
        this IEnumerable<T> sequence)
        {
            return sequence.LongCount();
        }
    }
}
