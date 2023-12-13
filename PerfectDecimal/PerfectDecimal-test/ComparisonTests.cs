using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
    internal class GreaterThanTests
    {
        [Test]
        public void Zero_Greater_Than_Zero_False()
        {
            PerfectDecimal subject = new();
            PerfectDecimal test = new(0, 4);

            Assert.That(subject > test, Is.False);
        }

        [Test]
        public void Negative_Numerator_Greater_Than_Negative()
        {
            PerfectDecimal subject = new(-1, 4);
            PerfectDecimal test = new(-1, 2);

            Assert.That(subject > test, Is.True);
        }

        [Test]
        public void Negative_Denominator_Not_Greater_Than_Positive()
        {
            PerfectDecimal subject = new(1, -2);
            PerfectDecimal test = new(1, 3);

            Assert.That(subject > test, Is.False);
        }

        [Test]
        public void Negative_Denominator_Greater_Than_Negative()
        {
            PerfectDecimal subject = new(1, -4);
            PerfectDecimal test = new(-1, 2);

            Assert.That(subject > test, Is.True);
        }

        [Test]
        public void Negative_Both_Greater_Than_Negative_Both()
        {
            PerfectDecimal subject = new(-1, -2);
            PerfectDecimal test = new(-1, -4);

            Assert.That(subject > test, Is.True);
        }

        [Test]
        public void Positive_Fraction_Greater_Than_Whole()
        {
            PerfectDecimal subject = new(7, 2);
            PerfectDecimal test = new(1, 1);

            Assert.That(subject > test, Is.True);
        }

        [Test]
        public void Negative_Not_Greater_Than_Zero()
        {
            PerfectDecimal subject = new(-3, 4);
            PerfectDecimal test = new();

            Assert.That(subject > test, Is.False);
        }

        [Test]
        public void Positive_Greater_Than_Zero()
        {
            PerfectDecimal subject = new(3, 4);
            PerfectDecimal test = new();

            Assert.That(subject > test, Is.True);
        }

        [Test]
        public void Same_Opposite_Part_Signs_Not_Greater()
        {
            PerfectDecimal subject = new(-1, 2);
            PerfectDecimal test = new(1, -2);

            Assert.That(subject > test, Is.False);
        }
    }

    internal class LessThanTests
    {
        [Test]
        public void Same_Opposite_Part_Signs_Not_Less()
        {
            PerfectDecimal subject = new(-1, 2);
            PerfectDecimal test = new(1, -2);

            Assert.That(subject < test, Is.False);
        }

        [Test]
        public void Zero_Less_Than_Zero_False()
        {
            PerfectDecimal subject = new();
            PerfectDecimal test = new(0, 4);

            Assert.That(subject < test, Is.False);
        }

        [Test]
        public void Negative_Numerator_Less_Than_Negative()
        {
            PerfectDecimal subject = new(-1, 2);
            PerfectDecimal test = new(-1, 4);

            Assert.That(subject < test, Is.True);
        }

        [Test]
        public void Negative_Denominator_Less_Than_Positive()
        {
            PerfectDecimal subject = new(1, -2);
            PerfectDecimal test = new(1, 4);

            Assert.That(subject < test, Is.True);
        }

        [Test]
        public void Negative_Denominator_Less_Than_Negative()
        {
            PerfectDecimal subject = new(1, -2);
            PerfectDecimal test = new(1, -4);

            Assert.That(subject < test, Is.True);
        }

        [Test]
        public void Negative_Both_Less_Than_Negative_Both()
        {
            PerfectDecimal subject = new(-1, -2);
            PerfectDecimal test = new(-1, -4);

            Assert.That(subject < test, Is.True);
        }

        [Test]
        public void Positive_Fraction_Less_Than_Whole()
        {
            PerfectDecimal subject = new(1, 7);
            PerfectDecimal test = new(7, 7);

            Assert.That(subject < test, Is.True);
        }

        [Test]
        public void Negative_Less_Than_Zero()
        {
            PerfectDecimal subject = new PerfectDecimal(-1, 2);
            PerfectDecimal test = new();

            Assert.That(subject < test, Is.True);
        }

        [Test]
        public void Positive_Not_Less_Than_Zero()
        {
            PerfectDecimal subject = new(1, 7);
            PerfectDecimal test = new();

            Assert.That(subject < test, Is.False);
        }
    }

    internal class IComparableOfTTests
    {
        [Test]
        public void Object_Is_Null()
        {
            PerfectDecimal subject = new(0, 1);
            PerfectDecimal? test = null;

            Assert.That(subject.CompareTo(test), Is.EqualTo(1));
        }

        [Test]
        public void Equal_Not_Reduced_Positive_Fraction()
        {
            PerfectDecimal subject = new(1, 2);
            PerfectDecimal test = new(4, 8);

            Assert.That(subject.CompareTo(test), Is.EqualTo(0));
        }

        [Test]
        public void Equal_Not_Reduced_Positive_Whole()
        {
            PerfectDecimal subject = new(2, 1);
            PerfectDecimal test = new(4, 2);

            Assert.That(subject.CompareTo(test), Is.EqualTo(0));
        }

        [Test]
        public void Equal_Not_Reduced_Negative_Fraction()
        {
            PerfectDecimal subject = new(-1, 2);
            PerfectDecimal test = new(-4, 8);

            Assert.That(subject.CompareTo(test), Is.EqualTo(0));
        }

        [Test]
        public void Equal_Not_Reduced_Negative_Whole()
        {
            PerfectDecimal subject = new(-2, 1);
            PerfectDecimal test = new(-8, 4);

            Assert.That(subject.CompareTo(test), Is.EqualTo(0));
        }

        [Test]
        public void Is_Larger()
        {
            PerfectDecimal subject = new();
            PerfectDecimal test = new(-1, 1);

            Assert.That(subject.CompareTo(test), Is.EqualTo(1));
        }

        [Test]
        public void Is_Smaller()
        {
            PerfectDecimal subject = new();
            PerfectDecimal test = new(1, 1);

            Assert.That(subject.CompareTo(test), Is.EqualTo(-1));
        }

        [Test]
        public void Is_Equal()
        {
            PerfectDecimal subject = new(9, 7);
            PerfectDecimal test = new(18, 14);

            Assert.That(subject.CompareTo(test), Is.EqualTo(0));
        }
    }

    internal class IComparableTests
    {
        [Test]
        public void Equal_Not_Reduced_Positive_Fraction()
        {
            PerfectDecimal subject = new(1, 2);
            PerfectDecimal test = new(4, 8);

            Assert.That(subject.CompareTo((object)test), Is.EqualTo(0));
        }

        [Test]
        public void Equal_Not_Reduced_Positive_Whole()
        {
            PerfectDecimal subject = new(2, 1);
            PerfectDecimal test = new(4, 2);

            Assert.That(subject.CompareTo((object)test), Is.EqualTo(0));
        }

        [Test]
        public void Equal_Not_Reduced_Negative_Fraction()
        {
            PerfectDecimal subject = new(-1, 2);
            PerfectDecimal test = new(-4, 8);

            Assert.That(subject.CompareTo((object)test), Is.EqualTo(0));
        }

        [Test]
        public void Equal_Not_Reduced_Negative_Whole()
        {
            PerfectDecimal subject = new(-2, 1);
            PerfectDecimal test = new(-8, 4);

            Assert.That(subject.CompareTo((object)test), Is.EqualTo(0));
        }

        [Test]
        public void Value_Is_Null()
        {
            PerfectDecimal subject = new();
            PerfectDecimal? test = null;

            Assert.That(subject.CompareTo((object)test!), Is.EqualTo(1));
        }

        [Test]
        public void Value_Is_Wrong_Type()
        {
            PerfectDecimal subject = new();
            object? test = 2;

            Assert.Throws<ArgumentException>(() => subject.CompareTo((object)test));
        }

        [Test]
        public void Is_Larger()
        {
            PerfectDecimal subject = new();
            PerfectDecimal test = new(-1, 1);

            Assert.That(subject.CompareTo((object)test), Is.EqualTo(1));
        }

        [Test]
        public void Is_Smaller()
        {
            PerfectDecimal subject = new();
            PerfectDecimal test = new(1, 1);

            Assert.That(subject.CompareTo((object)test), Is.EqualTo(-1));
        }

        [Test]
        public void Is_Equal()
        {
            PerfectDecimal subject = new(9, 7);
            PerfectDecimal test = new(18, 14);

            Assert.That(subject.CompareTo((object)test), Is.EqualTo(0));
        }
    }
}
