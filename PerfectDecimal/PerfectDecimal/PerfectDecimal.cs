using System.Numerics;

namespace PerfectDecimal
{
    public class PerfectDecimal
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
    }
}
