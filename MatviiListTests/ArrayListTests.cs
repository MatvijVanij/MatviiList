using MatviiList;
using NUnit.Framework;
using System;
namespace MatviiListTests
{
    public class Tests
    {
        [TestCase(2, 3, 19)]
        [TestCase(0, 5, 5)]
        [TestCase(4, 0, -5)]
        [TestCase(10, 4, -11)]
        public void SolvingEquations_WhenABSubstituteInEquation_ShouldSolveEquation(int a, int b, int expected)
        {
            int actual = ArrayList.(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(-1, -1)]
        public void SolvingEquations_WhenAEqualB_ShouldThrowDividedByZeroException(int a, int b)
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                Variables.SolvingEquations(a, b);
            });
        }
    }
}