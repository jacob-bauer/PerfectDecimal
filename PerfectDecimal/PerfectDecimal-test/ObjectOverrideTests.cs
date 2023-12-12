using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
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
