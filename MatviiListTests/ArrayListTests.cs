using MatviiList;
using NUnit.Framework;
using System;
namespace MatviiListTests
{
    public class Tests
    {
        [TestCase(new int[] { }, new int[] { 4, 4 })]
        [TestCase(new int[] { 4, 6, 3 }, new int[] { 4, 4, 4, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 4, 1, 2, 3 })]
        [TestCase(new int[] { -1, 2, 0 }, new int[] { 4, 4, -1, 2, 0 })]
        public void Add_WhenAddValue_ShouldAddToEnd(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddFirst(4);
            actual.AddFirst(4);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { }, new int[] { 9 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 9, 1, 2, 3 })]
        [TestCase(new int[] { -1, 2, 0, 4, 4 }, new int[] { 9, -1, 2, 0, 4, 4 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { 9, -3, 5, 9, 0, 67, 9, 87, -1 })]

        public void AddFirst_WhenAddValue_ShouldAddToFirst(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddFirst(9);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 6 })]
        [TestCase(new int[] { -1, 2, 0, 4, 4 }, new int[] { -1, 2, 0, 6, 4, 4 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 1, 2, 3, 6, 5, 7, 8 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9, 6, 0, 67, 9, 87, -1 })]
        public void AddByIndex_WhenAddValue_ShouldAddToFirst(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.AddByIndex(3, 6);
            Assert.AreEqual(actual, expected);

        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { -1, 2, 0, 4, 4 }, new int[] { -1, 2, 0, 4 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 1, 2, 3, 5, 7 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9, 0, 67, 9, 87, })]
        public void RemoveLast_WhenAddValue_ShouldRemoveLast(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveLast();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 2, 3, 5, 7, 8 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { 5, 9, 0, 67, 9, 87, -1 })]
        public void RemoveFirst_WhenAddValue_ShouldRemoveFirst(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveFirst();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 5 }, new int[] { 1, 2, 5 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 1, 2, 5, 7, 8 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 0, 67, 9, 87, -1 })]
        public void RemoveByIndex_WhenAddIndex_ShouldRemoveValueByIndex(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveByIndex(2);
            Assert.AreEqual(actual, expected);

        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 5, 9, 0, 67 })]
        public void RemoveLast_WhenAddNElements_ShouldRemoveLastNElements(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveLast(3);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 5, 7, 8 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { 0, 67, 9, 87, -1 })]
        public void RemoveFirst_WhenAddNElements_ShouldRemoveFirstNElements(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveFirst(3);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3, 6 }, new int[] { 1, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, -3, -5 }, new int[] { 1, 4, -3, -5 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 1, 5, 7, 8 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { -3, 0, 67, 9, 87, -1 })]
        public void RemoveByIndex_WhenAddNElementsAndIndex_ShouldRemoveNElementsbyIndex(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.RemoveByIndex(1, 2);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3, 6, 6 }, new int[] { 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, -3, -5 }, new int[] { 3 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 5 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { 67 })]
        public void GetValueByIndex_WhenAddIndex_ShouldValueForIndex(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.GetIndexByValue(4);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3, 6, 6 }, new int[] { 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, -3, -5 }, new int[] { 4 })]
        [TestCase(new int[] { 1, 2, 3, 5, 7, 8 }, new int[] { 8 })]
        [TestCase(new int[] { -3, 5, 9, 0, 67, 9, 87, -1 }, new int[] { 87 })]
        public void GetMax_WhenAddArray_ShouldValueMax(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.FindMaxElement();
            Assert.AreEqual(actual, expected);
        }


        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { -1, 0, 3 }, new int[] { 3, 0, -1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
        public void Revers_WhenAraayLoad_ShouldRevers(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.Revers();
            Assert.AreEqual(actual, expected);

        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { -9, 4, -8 }, new int[] { 4, -8, -9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
        public void SortDecrease_WhenAraayLoad_ShouldSortDecrease(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.SortDecrease();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 3, 2, 0, 1 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { 6, 4, 2, 5, 3, 1 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -9, 4, -8 }, new int[] { -9, -8, 4 })]
        public void SortIncrease_WhenAraayLoad_ShouldSortIncrease(int[] actualArr, int[] expectedArr)
        {
            ArrayList actual = new ArrayList(actualArr);
            ArrayList expected = new ArrayList(expectedArr);

            actual.SortIncrease();
            Assert.AreEqual(actual, expected);

        }




    }
}