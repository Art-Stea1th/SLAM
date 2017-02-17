﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;


namespace SLAM.Models.Mapping.Extensions {

    internal static partial class Extensions {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> sequence) {
            return sequence.IsNull() || sequence.IsEmpty();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull<T>(this IEnumerable<T> sequence) {
            return sequence == null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<T>(this IEnumerable<T> sequence) {
            return sequence.Count() < 1;
        }

        public static IEnumerable<TResult> DoSequential<TSource, TAnother, TResult>(
            this IEnumerable<TSource> sourceSequence, IEnumerable<TAnother> anotherSequence, Func<TSource, TAnother, TResult> selector) {

            var ssEnumerator = sourceSequence.GetEnumerator();
            var asEnumerator = anotherSequence.GetEnumerator();

            while (ssEnumerator.MoveNext() && asEnumerator.MoveNext()) {
                yield return selector.Invoke(ssEnumerator.Current, asEnumerator.Current);
            }
        }

        public static Vector Sum(this IEnumerable<Vector> sequence) {
            var enumerator = sequence.GetEnumerator();

            enumerator.MoveNext();
            var result = enumerator.Current;

            while (enumerator.MoveNext()) {
                result += enumerator.Current;
            }
            return result;
        }
    }    
}