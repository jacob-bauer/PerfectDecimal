using System.Numerics;

namespace ExtendedNumerics
{
    public class PerfectDecimal : IComparable,
                                  IComparable<PerfectDecimal>,
                                  IComparisonOperators<PerfectDecimal, PerfectDecimal, bool>,
                                  IEqualityOperators<PerfectDecimal, PerfectDecimal, bool>,
                                  IEquatable<PerfectDecimal>
    {
        private BigInteger _numerator;
        private BigInteger _denominator;

        public PerfectDecimal()
        {
            _numerator = BigInteger.Zero;
            _denominator = BigInteger.One;
        }

        public PerfectDecimal(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                string message = $"{nameof(denominator)} is zero."
                               + $" A {nameof(PerfectDecimal)} is a fraction of the form numerator / denominator."
                               + $" A fraction of the form n/0 is undefined."
                               + $" Please try creating a {nameof(PerfectDecimal)} with a {nameof(denominator)} that is not zero.";

                throw new ArgumentException(message, nameof(denominator));
            }

            else
            {
                _numerator = new BigInteger(numerator);
                _denominator = new BigInteger(denominator);
            }
        }

        public override bool Equals(object? value)
        {
            return value is PerfectDecimal other && CompareTo(other) == 0;
        }

        public bool Equals(PerfectDecimal? value)
        {
            return value is PerfectDecimal other && CompareTo(other) == 0;
        }

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
            var (leftNumerator, rightNumerator) = MakeLike(left, right);
            return leftNumerator < rightNumerator;
        }

        public static bool operator >(PerfectDecimal left, PerfectDecimal right)
        {
            var (leftNumerator, rightNumerator) = MakeLike(left, right);
            return leftNumerator > rightNumerator;
        }

        public static bool operator <=(PerfectDecimal left, PerfectDecimal right)
        {
            var (leftNumerator, rightNumerator) = MakeLike(left, right);
            return leftNumerator <= rightNumerator;
        }

        public static bool operator >=(PerfectDecimal left, PerfectDecimal right)
        {
            var (leftNumerator, rightNumerator) = MakeLike(left, right);
            return leftNumerator >= rightNumerator;
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

        private static (BigInteger leftNumerator, BigInteger rightNumerator) MakeLike(PerfectDecimal left,  PerfectDecimal right)
        {
            // If one of the denominators is negative, we need to make it positive while still maintaining the correct sign
            // for the fraction. This is because if one of the denominators is negative, the opposite sides numerator will
            // flip signs.

            // We do that here instead of disallowing negative numerators, so that callers can choose to create fractions
            // with negative numerators.

            // Cases:
            // Fraction is positive with two positive parts
            // Fraction is negative with negative numerator and positive denominator
            // --Fraction is negative with negative denominator and positive numerator
            // --Fraction is positive with two negative parts.

            // Since we cross multiply, we have to check both fractions

            BigInteger leftNumerator = left._numerator * right._denominator;
            BigInteger rightNumerator = right._numerator * left._denominator;

            return (leftNumerator, rightNumerator);


        }
    }
}
