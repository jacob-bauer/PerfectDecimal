using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
    internal class InequalityOperatorTests
    {
        [Test]
        public void Negative_Denominator_Negative_Numerator_Equal()
        {
            PerfectDecimal subject = new(1, -2);
            PerfectDecimal test = new(-1, 2);

            Assert.That(subject != test, Is.False);
        }

        [Test]
        public void Negative_Denominator_Negative_Numerator_not_Equal()
        {
            PerfectDecimal subject = new(2, -3);
            PerfectDecimal test = new(-3, 4);

            Assert.That(subject != test, Is.True);
        }

        [Test]
        public void Negative_Both_Negative_Both_Equal()
        {
            PerfectDecimal subject = new(-2, -5);
            PerfectDecimal test = new(-4, -10);

            Assert.That(subject != test, Is.False);
        }

        [Test]
        public void Negative_Both_Negative_Both_Not_Equal()
        {
            PerfectDecimal subject = new(-84, -56);
            PerfectDecimal test = new(-543, -75894);

            Assert.That(subject != test, Is.True);
        }

        [Test]
        public void Positive_Equal()
        {
            PerfectDecimal subject = new(3, 5);
            PerfectDecimal test = new(12, 20);

            Assert.That(subject != test, Is.False);
        }

        [Test]
        public void Positive_Not_Equal()
        {
            PerfectDecimal subject = new(3284, 923487);
            PerfectDecimal test = new(328497293, 395334345);

            Assert.That(subject != test, Is.True);
        }

        [Test]
        public void Negative_Positive_Not_Equal()
        {
            PerfectDecimal subject = new(-56, 90);
            PerfectDecimal test = new(1, 45);

            Assert.That(subject != test, Is.True);
        }
    }

    internal class EqualityOperatorTests
    {
        [Test]
        public void Negative_Denominator_Negative_Numerator_Equal()
        {
            PerfectDecimal subject = new(1, -2);
            PerfectDecimal test = new(-1, 2);

            Assert.That(subject == test, Is.True);
        }

        [Test]
        public void Negative_Denominator_Negative_Numerator_not_Equal()
        {
            PerfectDecimal subject = new(2, -3);
            PerfectDecimal test = new(-3, 4);

            Assert.That(subject == test, Is.False);
        }

        [Test]
        public void Negative_Both_Negative_Both_Equal()
        {
            PerfectDecimal subject = new(-2, -5);
            PerfectDecimal test = new(-4, -10);

            Assert.That(subject == test, Is.True);
        }

        [Test]
        public void Negative_Both_Negative_Both_Not_Equal()
        {
            PerfectDecimal subject = new(-84, -56);
            PerfectDecimal test = new(-543, -75894);

            Assert.That(subject == test, Is.False);
        }

        [Test]
        public void Positive_Equal()
        {
            PerfectDecimal subject = new(3, 5);
            PerfectDecimal test = new(12, 20);

            Assert.That(subject == test, Is.True);
        }

        [Test]
        public void Positive_Not_Equal()
        {
            PerfectDecimal subject = new(3284, 923487);
            PerfectDecimal test = new(328497293, 395334345);

            Assert.That(subject == test, Is.False);
        }

        [Test]
        public void Negative_Positive_Not_Equal()
        {
            PerfectDecimal subject = new(-56, 90);
            PerfectDecimal test = new(1, 45);

            Assert.That(subject == test, Is.False);
        }
    }
}
