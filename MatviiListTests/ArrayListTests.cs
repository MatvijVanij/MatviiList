using MatviiList;
using NUnit.Framework;
using System;
namespace MatviiListTests
{
    public class Tests
    {
        [TestCase(new int[] { 1, 1, 4, 0 }, 0)]
        [TestCase(new int[] { -5, -1, 3 }, -5)]
        [TestCase(new int[] { -14, 1, 2 }, -14)]
        [TestCase(new int[] { -10, 0, 4 }, -10)]
        public void InitializationArray_WhenAraaysLoaded_ShoudReternMinElementArrays(int[] a, int expected)
        {
            var t = new ArrayList();
            //int actual = OneArrays.OutputMinElementsArray(a);

            //Assert.AreEqual(expected, actual);
        }
    }
}