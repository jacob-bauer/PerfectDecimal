using NUnit.Framework.Interfaces;

namespace PerfectDecimal_test
{
    public class BigIntegerConstructorTests
    {
        [Test]
        public void Positive_Numerator_Positive_Denominator_Positive_Whole()
        {
            BigInteger part = new BigInteger(23);
            PerfectDecimal subject = new(part, part);
            PerfectDecimal test = new(1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Positive_Numerator_Positive_Denominator_Positive_Fraction()
        {
            BigInteger numerator = new(1);
            BigInteger denominator = new(3);
            PerfectDecimal subject = new(numerator, denominator);
            PerfectDecimal test = new(2, 6);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Positive_Numerator_Negative_Denominator_Negative_Whole()
        {
            BigInteger part = new(50);
            PerfectDecimal subject = new(part, -part);
            PerfectDecimal test = new(1, -1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Positive_Numerator_Negative_Denominator_Negative_Fraction()
        {
            BigInteger numerator = new(3);
            BigInteger denominator = new(-8);
            PerfectDecimal subject = new(numerator, denominator);
            PerfectDecimal test = new(6, -16);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Numerator_Negative_Denominator_Positive_Whole()
        {
            BigInteger part = new(5);
            PerfectDecimal subject = new(-part, -part);
            PerfectDecimal test = new(-10, -10);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Numerator_Negative_Denominator_Positive_Fraction()
        {
            BigInteger numerator = new(-7);
            BigInteger denominator = new(-9);
            PerfectDecimal subject = new(numerator, denominator);
            PerfectDecimal test = new(-14, -18);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Numerator_Positive_Denominator_Negative_Whole()
        {
            BigInteger part = new(11);
            PerfectDecimal subject = new(-part, part);
            PerfectDecimal test = new(-1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Numerator_Positive_Denominator_Negative_Fraction()
        {
            BigInteger numerator = new(-23);
            BigInteger denominator = new(79);
            PerfectDecimal subject = new(numerator, denominator);
            PerfectDecimal test = new(-46, 79 * 2);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Zero_Denominator_Throws()
        {
            BigInteger numerator = new(23);
            BigInteger denominator = new(0);

            Assert.Throws<ArgumentException>(() => new PerfectDecimal(numerator, -denominator));
        }

        [Test]
        public void Positive_Zero_Denominator_Throws()
        {
            BigInteger numerator = new(-67);
            BigInteger denominator = new(0);

            Assert.Throws<ArgumentException>(() => new PerfectDecimal(numerator, denominator));
        }

        [Test]
        public void Negative_Zero_Numerator_Positive_Zero()
        {
            BigInteger numerator = new(0);
            BigInteger denominator = new(97);

            PerfectDecimal subject = new(-numerator, denominator);
            PerfectDecimal test = new(-0, 1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Positive_Zero_Numerator_Positive_Zero()
        {
            BigInteger numerator = new(0);
            BigInteger denominator = new(-63);

            PerfectDecimal subject = new(numerator, denominator);
            PerfectDecimal test = new(0, -1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }
    }

    public class EmptyConstructorTests
    {
        [Test]
        public void EmptyConstructorCreatesOne()
        {
            PerfectDecimal subject = new();
            PerfectDecimal test = new(0, 1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }
    }

    public class IntegerConstructorTests
    {
        [Test]
        public void Positive_Numerator_Positive_Denominator_Positive_Whole()
        {
            PerfectDecimal subject = new(23, 23);
            PerfectDecimal test = new(1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Positive_Numerator_Positive_Denominator_Positive_Fraction()
        {
            PerfectDecimal subject = new(1, 3);
            PerfectDecimal test = new(2, 6);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Positive_Numerator_Negative_Denominator_Negative_Whole()
        {
            PerfectDecimal subject = new(50, -50);
            PerfectDecimal test = new(1, -1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Positive_Numerator_Negative_Denominator_Negative_Fraction()
        {
            PerfectDecimal subject = new(3, -8);
            PerfectDecimal test = new(6, -16);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Numerator_Negative_Denominator_Positive_Whole()
        {
            PerfectDecimal subject = new(-5, -5);
            PerfectDecimal test = new(-10, -10);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Numerator_Negative_Denominator_Positive_Fraction()
        {
            PerfectDecimal subject = new(-7, -9);
            PerfectDecimal test = new(-14, -18);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Numerator_Positive_Denominator_Negative_Whole()
        {
            PerfectDecimal subject = new(-11, 11);
            PerfectDecimal test = new(-1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Negative_Numerator_Positive_Denominator_Negative_Fraction()
        {
            PerfectDecimal subject = new(-23, 79);
            PerfectDecimal test = new(-46, 79 * 2);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
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
            PerfectDecimal test = new(-0, 1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }

        [Test]
        public void Positive_Zero_Numerator_Positive_Zero()
        {
            PerfectDecimal subject = new(0, -63);
            PerfectDecimal test = new(0, -1);

            Assert.Multiple(() =>
            {
                Assert.That(subject, Is.EqualTo(test));
                Assert.That(subject, Is.EqualTo(test));
            });
        }
    }
}