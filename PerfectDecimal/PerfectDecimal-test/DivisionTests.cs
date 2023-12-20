using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
    internal class DivisionTests
    {
        [Test]
        public void Zero_Zero()
        {
            PerfectDecimal left = new();
            PerfectDecimal right = new();

            Assert.Throws<DivideByZeroException>(() => _ = left / right);
        }

        [Test]
        public void Zero_One()
        {
            PerfectDecimal left = new();
            PerfectDecimal right = new(1, 1);

            PerfectDecimal subject = left / right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void Both_Both_Negative()
        {
            PerfectDecimal left = new(-1, -1);
            PerfectDecimal right = new(-1, -4);

            PerfectDecimal subject = left / right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(4, 1)));
        }

        [Test]
        public void Both_Negative_Positive()
        {
            PerfectDecimal left = new(-3, 4);
            PerfectDecimal right = new(-4, 4);

            PerfectDecimal subject = left / right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(3, 4)));
        }

        [Test]
        public void Both_Positive_Negative()
        {
            PerfectDecimal left = new(5, -7);
            PerfectDecimal right = new(13, -9);

            PerfectDecimal subject = left / right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(45, 91)));
        }

        [Test]
        public void Both_Both_Positive()
        {
            PerfectDecimal left = new(3, 6);
            PerfectDecimal right = new(1, 4);

            PerfectDecimal subject = left / right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(2, 1)));
        }

        [Test]
        public void Alternating_Mixed_Signs()
        {
            PerfectDecimal left = new(1, -3);
            PerfectDecimal right = new(-1, 3);

            PerfectDecimal subject = left / right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(1, 1)));
        }

        [Test]
        public void Opposite_Same_Signs()
        {
            PerfectDecimal left = new(1, 4);
            PerfectDecimal right = new(-2, -3);

            PerfectDecimal subject = left / right;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(3, 8)));
        }
    }
}
