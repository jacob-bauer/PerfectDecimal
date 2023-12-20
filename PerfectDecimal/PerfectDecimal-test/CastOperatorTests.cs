using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDecimal_test
{
    internal class ByteCastTests
    {
        [Test]
        public void Byte_Zero()
        {
            byte test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void Byte_Positive()
        {
            byte test = byte.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(byte.MaxValue, 1)));
        }

        [Test]
        public void SByte_Negative()
        {
            sbyte test = -sbyte.MaxValue / 2;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }

        [Test]
        public void SByte_Zero()
        {
            sbyte test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void SByte_Positive()
        {
            sbyte test = sbyte.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }
    }

    internal class ShortCastTests
    {
        [Test]
        public void UShort_Zero()
        {
            ushort test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void UShort_Positive()
        {
            ushort test = ushort.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(ushort.MaxValue, 1)));
        }

        [Test]
        public void Short_Negative()
        {
            short test = -short.MaxValue / 2;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }

        [Test]
        public void Short_Zero()
        {
            short test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void Short_Positive()
        {
            short test = short.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }
    }

    internal class IntCastTests
    {
        [Test]
        public void UInt_Zero()
        {
            uint test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void UInt_Positive()
        {
            uint test = uint.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(uint.MaxValue, 1)));
        }

        [Test]
        public void Int_Negative()
        {
            int test = -int.MaxValue / 2;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }

        [Test]
        public void Int_Zero()
        {
            int test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void Int_Positive()
        {
            int test = int.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }
    }

    internal class LongCastTests
    {
        [Test]
        public void ULong_Zero()
        {
            ulong test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void ULong_Positive()
        {
            ulong test = ulong.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(ulong.MaxValue, 1)));
        }

        [Test]
        public void Long_Negative()
        {
            long test = -long.MaxValue / 2;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }

        [Test]
        public void Long_Zero()
        {
            long test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void Long_Positive()
        {
            long test = long.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }
    }

    internal class Int128CastTests
    {
        [Test]
        public void UInt128_Zero()
        {
            UInt128 test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void UInt128_Positive()
        {
            UInt128 test = UInt128.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(UInt128.MaxValue, 1)));
        }

        [Test]
        public void Int128_Negative()
        {
            Int128 test = -Int128.MaxValue / 2;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }

        [Test]
        public void Int128_Zero()
        {
            Int128 test = 0;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void Int128_Positive()
        {
            Int128 test = Int128.MaxValue;
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }
    }

    internal class BigIntegerCastTests
    {
        [Test]
        public void BigInteger_Negative()
        {
            BigInteger test = new BigInteger(-long.MaxValue / 2);
            test = BigInteger.Pow(test, 4);

            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, BigInteger.One)));
        }

        [Test]
        public void BigInteger_Zero()
        {
            BigInteger test = new(0);
            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal()));
        }

        [Test]
        public void Int128_Positive()
        {
            BigInteger test = new BigInteger(ulong.MaxValue);
            test = BigInteger.Pow(test, 11);

            PerfectDecimal subject = (PerfectDecimal)test;

            Assert.That(subject, Is.EqualTo(new PerfectDecimal(test, 1)));
        }
    }
}
