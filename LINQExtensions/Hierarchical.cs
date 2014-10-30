using System;
using System.Collections.Generic;

namespace LINQExtensions
{
    public static class Hierarchical
    {
        /// <summary>
        /// Traverses the hierarchy. If the condition is true the subtree for this node will NOT be traversed, and the action
        /// will be executed only on the node.
        /// </summary>
        /// <param name="data">The list of nodes.</param>
        /// <param name="returnChildren"> Expression to access the descendents of the node.</param>
        /// <param name="condition">The condition on which the action will be executed.</param>
        /// <param name="action">The action which will be executed.</param>
        /// <exception cref="System.ArgumentException">features parameter cannot be null!</exception>
        public static void TraverseHierarchy<T>(
            this IEnumerable<T> data,
            Func<T, IEnumerable<T>> returnChildren,
            Func<T, bool> condition,
            Action<T> action)
        {
            if (data == null)
            {
                throw new ArgumentException("data parameter cannot be null!");
            }

            if (condition == null)
            {
                throw new ArgumentException("condition parameter cannot be null!");
            }

            if (action == null)
            {
                throw new ArgumentException("action parameter cannot be null!");
            }

            foreach (var e in data)
            {
                if (condition(e))
                {
                    action(e);
                }
                else
                {
                    TraverseHierarchy(returnChildren(e), returnChildren, condition, action);
                }
            }
        }

        /// <summary>
        /// Traverses the hierarchy and executes the action for each node.
        /// </summary>
        /// <param name="data">The list of nodes.</param>
        /// <param name="returnChildren"> Expression to access the descendents of the node.</param>
        /// <param name="action">The action which will be executed.</param>
        /// <exception cref="System.ArgumentException">features parameter cannot be null!</exception>
        public static void TraverseHierarchy<T>(
            this IEnumerable<T> data,
            Func<T, IEnumerable<T>> returnChildren,
            Action<T> action)
        {
            if (data == null)
            {
                throw new ArgumentException("data parameter cannot be null!");
            }

            if (action == null)
            {
                throw new ArgumentException("action parameter cannot be null!");
            }

            foreach (var e in data)
            {
                action(e);

                TraverseHierarchy(returnChildren(e), returnChildren, action);
            }
        }
    }
}
