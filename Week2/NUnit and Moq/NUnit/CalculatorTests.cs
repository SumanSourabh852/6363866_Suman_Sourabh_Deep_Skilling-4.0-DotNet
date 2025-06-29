using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, -1, -2)]
        public void Add_AddsTwoNumbers_ReturnsExpectedResult(int a, int b, int expected)
        {
            var result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("Demo: Ignored test")]
        public void IgnoredTest()
        {
            Assert.Fail("This should not run.");
        }
    }
}
