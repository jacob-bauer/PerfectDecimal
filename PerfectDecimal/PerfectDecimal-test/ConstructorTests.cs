using NUnit.Framework.Interfaces;

namespace PerfectDecimal_test
{
    public class EmptyConstructorTests
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

    public class IntegerConstructorTests
    {
        [Test]
        public void Positive_Numerator_Positive_Denominator_Positive_Whole()
        {
            PerfectDecimal subject = new(23, 23);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(new BigInteger(23)));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(23)));
            });
        }

        [Test]
        public void Positive_Numerator_Positive_Denominator_Positive_Fraction()
        {
            PerfectDecimal subject = new(1, 3);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(BigInteger.One));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(3)));
            });
        }

        [Test]
        public void Positive_Numerator_Negative_Denominator_Negative_Whole()
        {
            PerfectDecimal subject = new(50, -50);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(new BigInteger(50)));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(-50)));
            });
        }

        [Test]
        public void Positive_Numerator_Negative_Denominator_Negative_Fraction()
        {
            PerfectDecimal subject = new(3, -8);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(new BigInteger(3)));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(-8)));
            });
        }

        [Test]
        public void Negative_Numerator_Negative_Denominator_Positive_Whole()
        {
            PerfectDecimal subject = new(-5, -5);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(new BigInteger(-5)));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(-5)));
            });
        }

        [Test]
        public void Negative_Numerator_Negative_Denominator_Positive_Fraction()
        {
            PerfectDecimal subject = new(-7, -9);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(new BigInteger(-7)));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(-9)));
            });
        }

        [Test]
        public void Negative_Numerator_Positive_Denominator_Negative_Whole()
        {
            PerfectDecimal subject = new(-11, 11);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(new BigInteger(-11)));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(11)));
            });
        }

        [Test]
        public void Negative_Numerator_Positive_Denominator_Negative_Fraction()
        {
            PerfectDecimal subject = new(-23, 79);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(new BigInteger(-23)));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(79)));
            });
        }

        [Test]
        public void Negative_Zero_Denominator_Throws()
        {
            Assert.Throws<ArgumentException>(() => new PerfectDecimal(23, -0));
        }

        [Test]
        public void Positive_Zero_Denominator_Throws()
        {
            Assert.Throws<ArgumentException>(() => new PerfectDecimal(-67, 0));
        }

        [Test]
        public void Negative_Zero_Numerator_Positive_Zero()
        {
            PerfectDecimal subject = new(-0, 97);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(BigInteger.Zero));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(97)));
            });
        }

        [Test]
        public void Positive_Zero_Numerator_Positive_Zero()
        {
            PerfectDecimal subject = new(0, -63);

            Assert.Multiple(() =>
            {
                Assert.That(subject.Numerator, Is.EqualTo(BigInteger.Zero));
                Assert.That(subject.Denominator, Is.EqualTo(new BigInteger(-63)));
            });
        }
    }
}