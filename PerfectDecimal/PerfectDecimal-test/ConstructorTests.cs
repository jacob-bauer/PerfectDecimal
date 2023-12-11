namespace PerfectDecimal_test
{
    public class ConstructorTests
    {
        [Test]
        public void EmptyConstructorCreatesOne()
        {
            PerfectDecimal subject = new();

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(BigInteger.Zero));
                Assert.That(subject.Denominator, Is.EqualTo(BigInteger.One));
            });
        }
    }
}