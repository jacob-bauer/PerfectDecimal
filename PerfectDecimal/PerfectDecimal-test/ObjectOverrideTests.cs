using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
    internal class ObjectEqualsTests
    {
        [Test]
        public void Value_Is_Null()
        {
            PerfectDecimal subject = new(1, 6);
            object? test = null;

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Positive_Value_Is_Smaller_Fraction()
        {
            PerfectDecimal subject = new(1, 6);
            object? test = new PerfectDecimal(1, 7);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Negative_Value_Is_Smaller_Fraction()
        {
            // Less than operator moves towards negative infinity, that is, -3 is less than -2
            PerfectDecimal subject = new(-2, 3);
            object? test = new PerfectDecimal(-3, 4);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Positive_Value_Is_Smaller_Whole()
        {
            PerfectDecimal subject = new(3, 1);
            object? test = new PerfectDecimal(2, 1);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Negative_Value_Is_Smaller_Whole()
        {
            PerfectDecimal subject = new(-2, 1);
            object? test = new PerfectDecimal(-3, 1);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Positive_Value_Is_Equal_Fraction()
        {
            PerfectDecimal subject = new(2, 3);
            object? test = new PerfectDecimal(4, 6);

            Assert.That(subject.Equals(test), Is.EqualTo(true));
        }

        [Test]
        public void Negative_Value_Is_Equal_Fraction()
        {
            PerfectDecimal subject = new(-6, 4);
            object? test = new PerfectDecimal(-12, 8);

            Assert.That(subject.Equals(test), Is.EqualTo(true));
        }

        [Test]
        public void Positive_Value_Is_Equal_Whole()
        {
            PerfectDecimal subject = new(2, 1);
            object? test = new PerfectDecimal(4, 2);

            Assert.That(subject.Equals(test), Is.EqualTo(true));
        }

        [Test]
        public void Negative_Value_Is_Equal_Whole()
        {
            PerfectDecimal subject = new(-3, 1);
            object? test = new PerfectDecimal(-9, 3);

            Assert.That(subject.Equals(test), Is.EqualTo(true));
        }

        [Test]
        public void Positive_Value_Larger_Fraction()
        {
            PerfectDecimal subject = new(1, 2);
            object? test = new PerfectDecimal(3, 4);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Negative_Value_Larger_Fraction()
        {
            PerfectDecimal subject = new(-3, 4);
            object? test = new PerfectDecimal(1, 2);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Positive_Value_Larger_Whole()
        {
            PerfectDecimal subject = new(5, 1);
            object? test = new PerfectDecimal(6, 1);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }

        [Test]
        public void Negative_Value_Larger_Whole()
        {
            PerfectDecimal subject = new(-7, 1);
            object? test = new PerfectDecimal(-6, 1);

            Assert.That(subject.Equals(test), Is.EqualTo(false));
        }
    }

    internal class ObjectGetHashCodeTests
    {
        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion", "NUnit2009:The same value has been provided as both the actual and the expected argument", Justification = "Object.GetHashCode should return the same value if called mutliple times for the same object.")]
        public void Hashcode_Same_For_Same_Object()
        {
            PerfectDecimal subject = new();

            Assert.That(subject.GetHashCode(), Is.EqualTo(subject.GetHashCode()));
        }

        [Test]
        public void Hashcode_Same_For_Equal_Reduced()
        {
            PerfectDecimal subject = new(2, 3);
            PerfectDecimal test = new(2, 3);

            Assert.That(subject.GetHashCode(), Is.EqualTo(test.GetHashCode()));
        }

        [Test]
        public void Hashcode_Same_For_Equal_Not_Reduced()
        {
            PerfectDecimal subject = new(7, 9);
            PerfectDecimal test = new(14, 18);

            Assert.That(subject.GetHashCode(), Is.EqualTo(test.GetHashCode()));
        }
    }
}
