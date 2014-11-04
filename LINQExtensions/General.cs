using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExtensions
{
    public static class Extensions
    {
        /// <summary>
        /// Replaces a null reference with an empty collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <returns>The collection or an empty one</returns>
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Checks if the given collection contains any items. Will not throw an exception if the source is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <returns>True if the collection is empty, false otherwise.</returns>
        public static bool SafeAny<T>(this IEnumerable<T> source)
        {
            return source.NullToEmpty().Any();
        }

        /// <summary>
        /// Checks if the given collection contains any items that satisfies the given condition. Will not throw an exception if the source is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <param name="predicate">The condition.</param>
        /// <returns>True if the collection is empty, false otherwise.</returns>
        public static bool SafeAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.NullToEmpty().Any(predicate);
        }


        /// <summary>
        /// Checks if the given collection is empty. Will not throw an exception if the source is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <returns>True if the collection is empty, false otherwise.</returns>
        public static bool SafeNone<T>(this IEnumerable<T> source)
        {
            return !source.NullToEmpty().Any();
        }

        /// <summary>
        /// Checks if the given collection contains 0 items that satisfies the given condition. Will not throw an exception if the source is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <param name="predicate">The condition.</param>
        /// <returns>True if the collection is empty, false otherwise.</returns>
        public static bool SafeNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.NullToEmpty().Any(predicate);
        }


        /// <summary>
        /// Determines whether a collection implementing the IEnumerable interface is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <returns>
        ///   <c>true</c> if the collection is null or empty otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Checks if the given collection is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <returns>True if the collection is empty, false otherwise.</returns>
        public static bool None<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Checks if the given collection contains 0 items that satisfies the given condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <param name="predicate">The condition.</param>
        /// <returns>True if the collection is empty, false otherwise.</returns>
        public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.Any(predicate);
        }

        /// <summary>
        /// Performs an action on every item in the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The collection reference.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                throw new ArgumentException("source parameter cannot be null!");
            }

            if (action == null)
            {
                throw new ArgumentException("action parameter cannot be null!");
            }

            foreach (var i in source)
            {
                action(i);
            }
        }
    }
}
