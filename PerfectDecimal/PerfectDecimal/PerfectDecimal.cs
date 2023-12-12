using System.Numerics;

namespace ExtendedNumerics
{
    public class PerfectDecimal : IComparable
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

        public PerfectDecimal(int numerator, int denominator) : this(new BigInteger(numerator), new BigInteger(denominator))
        {
        }

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

        public int CompareTo(object? obj)
        {
            // Make fractions like

            // Compare Numerators
        }

        public PerfectDecimal Reduce()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(_numerator, _denominator);

            BigInteger numerator = _numerator / gcd;
            BigInteger denominator = _denominator / gcd;

            return new PerfectDecimal(numerator, denominator);
        }
    }
}
