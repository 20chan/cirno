using System;

namespace cirno.Tests.Geometry
{
    public static class TestHelpers
    {
        public static float NextFloat(this Random random, float min = float.MinValue, float max = float.MaxValue)
        {
            var result = random.NextDouble() * (max - (double)min) + min;
            return (float)result;
        }
    }
}