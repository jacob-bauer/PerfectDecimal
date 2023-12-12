using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
    internal class IEquatableTests
    {
        [Test]
        public void Value_Is_Null()
        {
            PerfectDecimal subject = new(1, 6);
            PerfectDecimal? test = null;

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Positive_Value_Is_Smaller_Fraction()
        {
            PerfectDecimal subject = new(1, 6);
            PerfectDecimal? test = new(1, 7);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Negative_Value_Is_Smaller_Fraction()
        {
            // Less than operator moves towards negative infinity, that is, -3 is less than -2
            PerfectDecimal subject = new(-2, 3);
            PerfectDecimal? test = new(-3, 4);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Positive_Value_Is_Smaller_Whole()
        {
            PerfectDecimal subject = new(3, 1);
            PerfectDecimal? test = new(2, 1);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Negative_Value_Is_Smaller_Whole()
        {
            PerfectDecimal subject = new(-2, 1);
            PerfectDecimal? test = new(-3, 1);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Positive_Value_Is_Equal_Fraction()
        {
            PerfectDecimal subject = new(2, 3);
            PerfectDecimal? test = new(4, 6);

            Assert.That(subject.Equals(test), Is.EqualTo(true));
        }

        [Test]
        public void Negative_Value_Is_Equal_Fraction()
        {
            PerfectDecimal subject = new(-6, 4);
            PerfectDecimal? test = new(-12, 8);

            Assert.That(subject.Equals(test), Is.EqualTo(true));
        }

        [Test]
        public void Positive_Value_Is_Equal_Whole()
        {
            PerfectDecimal subject = new(2, 1);
            PerfectDecimal? test = new(4, 2);

            Assert.That(subject.Equals(test), Is.EqualTo(true));
        }

        [Test]
        public void Negative_Value_Is_Equal_Whole()
        {
            PerfectDecimal subject = new(-3, 1);
            PerfectDecimal? test = new(-9, 3);

            Assert.That(subject.Equals(test), Is.EqualTo(true));
        }

        [Test]
        public void Positive_Value_Larger_Fraction()
        {
            PerfectDecimal subject = new(1, 2);
            PerfectDecimal? test = new(3, 4);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Negative_Value_Larger_Fraction()
        {
            PerfectDecimal subject = new(-3, 4);
            PerfectDecimal? test = new(1, 2);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Positive_Value_Larger_Whole()
        {
            PerfectDecimal subject = new(5, 1);
            PerfectDecimal? test = new(6, 1);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Negative_Value_Larger_Whole()
        {
            PerfectDecimal subject = new(-7, 1);
            PerfectDecimal? test = new(-6, 1);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }
    }
}
