using MatviiList;
using NUnit.Framework;
using System;
namespace MatviiListTests
{
    public class Tests
    {
        [Test]
        public void Add_WhenAddValue_ShouldAddToEnd()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            ArrayList expected = new ArrayList(new int[] { 1, 2  });

            expected.Add(3);
            Assert.AreEqual(expected,actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        public void Add_WhenAddOneNumber_ShouldAddOneNumberToEnd(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(initialValue);
            ArrayList expected = new ArrayList(expectedValue);

            actual.Add(4);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
        public void Reverse_WhenList_ShouldReverseList(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(initialValue);
            ArrayList expected = new ArrayList(expectedValue);

            actual.Revers();

            Assert.AreEqual(expected, actual);
        }

    }
}