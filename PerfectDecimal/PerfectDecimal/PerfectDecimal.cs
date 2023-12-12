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

        public BigInteger Numerator { get => _numerator; }
        public BigInteger Denominator { get => _denominator; }

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
                // make fractions like then compare
                BigInteger myNumerator = _numerator * perfectDecimal.Denominator;
                BigInteger objNumerator = perfectDecimal.Numerator * _denominator;

                if (myNumerator < objNumerator)
                    return -1;

                else if (myNumerator == objNumerator)
                    return 0;

                else
                    return 1;
            }

            else if (value is null)
                return 1;

            else
                throw new ArgumentException($"Object must be of type {nameof(PerfectDecimal)}.");
        }

        public int CompareTo(PerfectDecimal value)
        {
            BigInteger myNumerator = _numerator * value.Denominator;
            BigInteger valueNumerator = value.Numerator * _denominator;

            if (myNumerator < valueNumerator)
                return -1;

            else if (myNumerator == valueNumerator)
                return 0;

            else
                return 1;
        }

        public static bool operator <(PerfectDecimal left, PerfectDecimal right)
        {
            BigInteger leftNumerator = left.Numerator * right.Denominator;
            BigInteger rightNumerator = right.Numerator * left.Denominator;

            return leftNumerator < rightNumerator;
        }

        public static bool operator >(PerfectDecimal left, PerfectDecimal right)
        {
            BigInteger leftNumerator = left.Numerator * right.Denominator;
            BigInteger rightNumerator = right.Numerator * left.Denominator;

            return leftNumerator > rightNumerator;
        }

        public static bool operator <=(PerfectDecimal left, PerfectDecimal right)
        {
            BigInteger leftNumerator = left.Numerator * right.Denominator;
            BigInteger rightNumerator = right.Numerator * left.Denominator;

            return leftNumerator <= rightNumerator;
        }

        public static bool operator >=(PerfectDecimal left, PerfectDecimal right)
        {
            BigInteger leftNumerator = left.Numerator * right.Denominator;
            BigInteger rightNumerator = right.Numerator * left.Denominator;

            return leftNumerator >= rightNumerator;
        }

        public static bool operator ==(PerfectDecimal left, PerfectDecimal right)
        {
            BigInteger leftNumerator = left.Numerator * right.Denominator;
            BigInteger rightNumerator = right.Numerator * left.Denominator;

            return leftNumerator == rightNumerator;
        }

        public static bool operator !=(PerfectDecimal left, PerfectDecimal right)
        {
            BigInteger leftNumerator = left.Numerator * right.Denominator;
            BigInteger rightNumerator = right.Numerator * left.Denominator;

            return leftNumerator != rightNumerator;
        }
    }
}
