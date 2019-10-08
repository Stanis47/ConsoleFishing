using System;
using System.Security.Cryptography;

namespace Engine
{
    public static class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static double NumberBetween(double minimumValue, double maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            double multipler = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.000000001d);

            double range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multipler * range);

            return (minimumValue + randomValueInRange);
        }
    }
}
