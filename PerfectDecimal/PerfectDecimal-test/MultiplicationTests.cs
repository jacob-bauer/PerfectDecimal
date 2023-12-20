using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
    internal class MultiplicationTests
    {
        [Test]
        public void Zero_Zero()
        {
            PerfectDecimal left = new();
            PerfectDecimal right = new();

            PerfectDecimal subject = left * right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void Both_Both_Negative()
        {
            PerfectDecimal left = new(-1, -1);
            PerfectDecimal right = new(-1, -4);

            PerfectDecimal subject = left + right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(-5, -4)));
        }

        [Test]
        public void Both_Negative_Positive()
        {
            PerfectDecimal left = new(-3, 4);
            PerfectDecimal right = new(-4, 4);

            PerfectDecimal subject = left + right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(-7, 4)));
        }

        [Test]
        public void Both_Positive_Negative()
        {
            PerfectDecimal left = new(5, -7);
            PerfectDecimal right = new(13, -9);

            PerfectDecimal subject = left + right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(-136, 63)));
        }

        [Test]
        public void Both_Both_Positive()
        {
            PerfectDecimal left = new(3, 6);
            PerfectDecimal right = new(1, 4);

            PerfectDecimal subject = left + right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(3, 4)));
        }

        [Test]
        public void Alternating_Mixed_Signs()
        {
            PerfectDecimal left = new(1, -3);
            PerfectDecimal right = new(-1, 3);

            PerfectDecimal subject = left + right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(-2, 3)));
        }

        [Test]
        public void Opposite_Same_Signs()
        {
            PerfectDecimal left = new(1, 4);
            PerfectDecimal right = new(-2, -3);

            PerfectDecimal subject = left + right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(-11, -12)));
        }
    }
}
