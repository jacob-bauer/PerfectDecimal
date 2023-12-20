using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ExtendedNumerics
{
    public class PerfectDecimal : IComparable,
                                  IComparable<PerfectDecimal>,
                                  IComparisonOperators<PerfectDecimal, PerfectDecimal, bool>,
                                  IEqualityOperators<PerfectDecimal, PerfectDecimal, bool>,
                                  IEquatable<PerfectDecimal>,
                                  IAdditionOperators<PerfectDecimal, PerfectDecimal, PerfectDecimal>,
                                  IAdditiveIdentity<PerfectDecimal, PerfectDecimal>
    {
        private BigInteger _numerator;
        private BigInteger _denominator;


        public static PerfectDecimal AdditiveIdentity { get => new PerfectDecimal(); }


        public PerfectDecimal()
        {
            _numerator = BigInteger.Zero;
            _denominator = BigInteger.One;
        }

        public PerfectDecimal(int numerator, int denominator) : this(new BigInteger(numerator), new BigInteger(denominator)) { }

        public PerfectDecimal(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == BigInteger.Zero)
            {
                string message = $"{nameof(denominator)} is zero."
                               + $" A {nameof(PerfectDecimal)} is a fraction of the form numerator / denominator."
                               + $" A fraction of the form n/0 is undefined."
                               + $" Please try creating a {nameof(PerfectDecimal)} with a {nameof(denominator)} that is not zero.";

                throw new ArgumentException(message, nameof(denominator));
            }

            else
            {
                _numerator = numerator;
                _denominator = denominator;
            }
        }

        public override bool Equals(object? value) => value is PerfectDecimal other && CompareTo(other) == 0;

        public bool Equals(PerfectDecimal? value) => value is PerfectDecimal other && CompareTo(other) == 0;

        public override int GetHashCode()
        {
            // Since this has to return the same hashcode for
            // objects that may have different numerators and denominators
            // but which are actually equal in value, and we don't have
            // a reference to another PerfectDecimal to compare to
            // we must reduce the fraction before generating the hashcode
            BigInteger gcd = BigInteger.GreatestCommonDivisor(_numerator, _denominator);

            BigInteger numerator = _numerator / gcd;
            BigInteger denominator = _denominator / gcd;

            return HashCode.Combine(numerator, denominator);
        }

        public int CompareTo(object? value)
        {
            if (value is PerfectDecimal perfectDecimal)
            {
                var (leftNumerator, rightNumerator) = MakeLike(this, perfectDecimal);

                if (leftNumerator < rightNumerator)
                    return -1;

                else if (leftNumerator == rightNumerator)
                    return 0;

                else
                    return 1;
            }

            else if (value is null)
                return 1;

            else
                throw new ArgumentException($"Object must be of type {nameof(PerfectDecimal)}.");
        }

        public int CompareTo(PerfectDecimal? value)
        {
            if (value is not null)
            {
                var (leftNumerator, rightNumerator) = MakeLike(this, value);

                if (leftNumerator < rightNumerator)
                    return -1;

                else if (leftNumerator == rightNumerator)
                    return 0;

                else return 1;
            }

            else
                return 1;
        }

        public static bool operator <(PerfectDecimal left, PerfectDecimal right)
        {
            var (leftNumerator, rightNumerator, leftDenominator, rightDenominator) = MassageFractionSigns(left, right);
            return (leftNumerator * rightDenominator) < (rightNumerator * leftDenominator);
        }

        public static bool operator >(PerfectDecimal left, PerfectDecimal right)
        {
            var (leftNumerator, rightNumerator, leftDenominator, rightDenominator) = MassageFractionSigns(left, right);
            return (leftNumerator * rightDenominator) > (rightNumerator * leftDenominator);
        }

        public static bool operator <=(PerfectDecimal left, PerfectDecimal right)
        {
            var (leftNumerator, rightNumerator, leftDenominator, rightDenominator) = MassageFractionSigns(left, right);
            return (leftNumerator * rightDenominator) <= (rightNumerator * leftDenominator);
        }

        public static bool operator >=(PerfectDecimal left, PerfectDecimal right)
        {
            var (leftNumerator, rightNumerator, leftDenominator, rightDenominator) = MassageFractionSigns(left, right);
            return (leftNumerator * rightDenominator) >= (rightNumerator * leftDenominator);
        }

        public static bool operator ==(PerfectDecimal? left, PerfectDecimal? right)
        {
            if (left is not null && right is not null)
            {
                var (leftNumerator, rightNumerator) = MakeLike(left, right);
                return leftNumerator == rightNumerator;
            }

            else
                return false;
        }

        public static bool operator !=(PerfectDecimal? left, PerfectDecimal? right)
        {
            if (left is not null && right is not null)
            {
                var (leftNumerator, rightNumerator) = MakeLike(left, right);
                return leftNumerator != rightNumerator;
            }

            else
                return false;
        }

        public static implicit operator PerfectDecimal(sbyte value) => new(new BigInteger(value), BigInteger.One);

        public static implicit operator PerfectDecimal(byte value) => new(new BigInteger(value), BigInteger.One);

        public static implicit operator PerfectDecimal(short value) => new(new BigInteger(value), BigInteger.One);

        public static implicit operator PerfectDecimal(ushort value) => new(new BigInteger(value), BigInteger.One);

        public static implicit operator PerfectDecimal(int value) => new(new BigInteger(value), BigInteger.One);

        public static implicit operator PerfectDecimal(uint value) => new(new BigInteger(value), BigInteger.One);

        public static implicit operator PerfectDecimal(long value) => new(new BigInteger(value), BigInteger.One);

        public static implicit operator PerfectDecimal(ulong value) => new(new BigInteger(value), BigInteger.One);

        public static implicit operator PerfectDecimal(Int128 value) => new((BigInteger)value, BigInteger.One);

        public static implicit operator PerfectDecimal(UInt128 value) => new((BigInteger)value, BigInteger.One);

        public static implicit operator PerfectDecimal(BigInteger value) => new(value, BigInteger.One);

        public static PerfectDecimal operator +(PerfectDecimal left, PerfectDecimal right)
        {
            var likeNumerators = MakeLike(left, right);

            BigInteger numerator = likeNumerators.leftNumerator + likeNumerators.rightNumerator;
            BigInteger denominator = left._denominator * right._denominator;

            return new PerfectDecimal(numerator, denominator);
        }

        private static (BigInteger leftNumerator, BigInteger rightNumerator) MakeLike(PerfectDecimal left,  PerfectDecimal right) => (left._numerator * right._denominator, right._numerator * left._denominator);

        private static (BigInteger leftNumerator, BigInteger rightNumerator, BigInteger leftDenominator, BigInteger rightDenominator) MassageFractionSigns(PerfectDecimal left, PerfectDecimal right)
        {
            BigInteger leftNumerator = left._numerator;
            BigInteger rightNumerator = right._numerator;
            BigInteger leftDenominator = left._denominator;
            BigInteger rightDenominator = right._denominator;

            if (leftDenominator.Sign == -1)
            {
                leftNumerator = -leftNumerator;
                leftDenominator = -leftDenominator;
            }

            if (rightDenominator.Sign == -1)
            {
                rightNumerator = -rightNumerator;
                rightDenominator = -rightDenominator;
            }

            return (leftNumerator, rightNumerator, leftDenominator, rightDenominator);
        }
    }
}
