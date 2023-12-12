using NUnit.Framework.Interfaces;

namespace PerfectDecimal_test
{
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