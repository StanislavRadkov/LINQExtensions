using System;
using System.Linq;
using System.Collections.Generic;
using LINQExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQExtensionsTests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void TestNullToEmpty()
        {
            CollectionAssert.AreEqual(new int[] { }, (null as int[]).NullToEmpty().ToArray());
        }

        [TestMethod]
        public void TestNullToEmptyForEmptyArray()
        {
            CollectionAssert.AreEqual(new int[] { }, (new int[] { }).NullToEmpty().ToArray());
        }

        [TestMethod]
        public void TestNullToEmptyForFilledArray()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, (new int[] { 1, 2, 3, 4, 5 }).NullToEmpty().ToArray());
        }

        [TestMethod]
        public void TestSafeAny()
        {
            Assert.AreEqual(false, (null as int[]).SafeAny());
        }

        [TestMethod]
        public void TestSafeAnyForEmpty()
        {
            Assert.AreEqual(false, (new int[] { }).SafeAny());
        }

        [TestMethod]
        public void TestSafeAnyForFilleldArray()
        {
            Assert.AreEqual(true, (new int[] {1, 2, 3 }).SafeAny());
        }

        [TestMethod]
        public void TestSafeAnyWithPredicate()
        {
            Assert.AreEqual(false, (null as int[]).SafeAny(x => x % 2 == 0));
        }

        [TestMethod]
        public void TestSafeAnyForEmptyWithPredicate()
        {
            Assert.AreEqual(false, (new int[] { }).SafeAny(x => x % 2 == 0));
        }

        [TestMethod]
        public void TestSafeAnyForFilleldArrayWithPredicate()
        {
            Assert.AreEqual(true, (new int[] { 1, 2, 3 }).SafeAny(x => x % 2 == 0));
        }
        
        [TestMethod]
        public void TestSafeNone()
        {
            Assert.AreEqual(true, (null as int[]).SafeNone());
        }

        [TestMethod]
        public void TestSafeNoneForEmpty()
        {
            Assert.AreEqual(true, (new int[] { }).SafeNone());
        }

        [TestMethod]
        public void TestSafeNoneForFilleldArray()
        {
            Assert.AreEqual(false, (new int[] { 1, 2, 3 }).SafeNone());
        }

        [TestMethod]
        public void TestSafeNoneWithPredicate()
        {
            Assert.AreEqual(true, (null as int[]).SafeNone(x => x % 2 == 0));
        }

        [TestMethod]
        public void TestSafeNoneForEmptyWithPredicate()
        {
            Assert.AreEqual(true, (new int[] { }).SafeNone(x => x % 2 == 0));
        }

        [TestMethod]
        public void TestSafeNoneForFilleldArrayWithPredicate()
        {
            Assert.AreEqual(false, (new int[] { 1, 2, 3 }).SafeNone(x => x % 2 == 0));
        }

        [TestMethod]
        public void TestIsNullOrEmpty()
        {
            Assert.AreEqual(true, (null as int[]).IsNullOrEmpty());
        }

        [TestMethod]
        public void TestIsNullOrEmptyForEmptyArray()
        {
            Assert.AreEqual(true, (new int[] { }).IsNullOrEmpty());
        }

        [TestMethod]
        public void TestIsNullOrEmptyForFilledArray()
        {
            Assert.AreEqual(false, (new int[] { 1, 2, 3 }).IsNullOrEmpty());
        }

        [TestMethod]
        public void TestNoneForEmpty()
        {
            Assert.AreEqual(true, (new int[] { }).None());
        }

        [TestMethod]
        public void TestNoneForFilleldArray()
        {
            Assert.AreEqual(false, (new int[] { 1, 2, 3 }).None());
        }

        [TestMethod]
        public void TestNoneForEmptyWithPredicate()
        {
            Assert.AreEqual(true, (new int[] { }).None(x => x % 2 == 0));
        }

        [TestMethod]
        public void TestNoneForFilleldArrayWithPredicate()
        {
            Assert.AreEqual(false, (new int[] { 1, 2, 3 }).None(x => x % 2 == 0));
        }

        [TestMethod]
        public void TestForEach()
        {
            var list = new List<int>();
            var data = new int[] { };
            data.ForEach(x => list.Add(x));

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestForEachFilledArray()
        {
            var list = new List<int>();
            var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};
            data.ForEach(x => list.Add(x));

            CollectionAssert.AreEqual(data, list);
        }
    }
}
