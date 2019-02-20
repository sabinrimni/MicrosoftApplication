using NUnit.Framework;

namespace MakeChange.Tests
{
    [TestFixture]
    public class MakeChangeTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ReturnNoChange(int situation)
        {
            Assert.That(Program.MakeChange(situation), Is.EqualTo(0), "No change should be given.");
        }

        [Test]
        [TestCase(new[] { 100, 50, 20, 10, 5, 1 })]
        public void ReturnExactChange(int[] situations)
        {
            foreach (var situation in situations)
            {
                Assert.That(Program.MakeChange(situation), Is.EqualTo(1), "Exact change should be 1.");
            }
        }

        [Test]
        [TestCase(new[] { 4, 9, 19, 49, 99, 199 })]
        public void ReturnLowerEdgeCaseChange(int[] situations)
        {
            var baseResult = 4;
            foreach (var situation in situations)
            {
                Assert.That(Program.MakeChange(situation), Is.EqualTo(baseResult), "Lower edge cases should be " + baseResult + ".");
                baseResult++;
            }
        }

        [Test]
        [TestCase(new[] { 6, 11, 21, 51, 101 })]
        public void ReturnUpperEdgeCaseChange(int[] situations)
        {
            foreach (var situation in situations)
            {
                Assert.That(Program.MakeChange(situation), Is.EqualTo(2), "Upper edge cases should be 2.");
            }
        }

        [Test]
        [TestCase(135)]
        public void ReturnArbitraryChange(int situation)
        {
            Assert.That(Program.MakeChange(situation), Is.EqualTo(4));
        }
    }
}
