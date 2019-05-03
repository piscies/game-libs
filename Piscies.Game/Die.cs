using System;

namespace Piscies.Game
{
    public static class Die
    {
        private static Random randomGenerator = new Random(Environment.TickCount);

        /// <summary>
        /// Rolls a die. Min value is always 1.
        /// </summary>
        /// <param name="nSides">Number of sides of the die. This is the INCLUSIVE maxValue.</param>
        /// <returns></returns>
        public static int Roll(int nSides)
        {
            return randomGenerator.Next(1, nSides + 1);
        }

        /// <summary>
        /// Rolls a random number using Random class.
        /// </summary>
        /// <param name="minValue">INCLUSIVE min value.</param>
        /// <param name="maxValue">INCLUSIVE max value</param>
        /// <returns></returns>
        public static int RandomNumber(int minValue, int maxValue)
        {
            return randomGenerator.Next(minValue, maxValue + 1);
        }
    }
}
