using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
    internal class IComparableTests
    {
        [Test]
        public void Value_Is_Null()
        {
            PerfectDecimal subject = new();
            PerfectDecimal? test = null;

            Assert.That(subject.CompareTo(test), Is.EqualTo(1));
        }

        [Test]
        public void Value_Is_Wrong_Type()
        {
            PerfectDecimal subject = new();
            object? test = 2;

            Assert.Throws<ArgumentException>(() => subject.CompareTo(test));
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
}
