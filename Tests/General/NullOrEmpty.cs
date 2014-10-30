using System.Linq;
using LINQExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.General
{
    [TestClass]
    public class NullOrEmpty
    {
        [TestMethod]
        public void TestNullSource()
        {
            int[] array = null;

            Assert.AreNotEqual(array.NullToEmpty(), null);
        }

        [TestMethod]
        public void TestInitializedSource()
        {
            var array = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            Assert.AreEqual(array.NullToEmpty().Count(x => x % 2 == 0), 5);
        }

        [TestMethod]
        public void TestEmptySource()
        {
            var array = new int[0];

            Assert.AreEqual(array.NullToEmpty().Count(), 0);
        }
    }
}
