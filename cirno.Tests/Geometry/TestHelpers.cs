using System;

namespace cirno.Tests.Geometry
{
    public static class TestHelpers
    {
        public static float NextFloat(this Random random)
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);
            var randomFloat = float.NaN;
            while (float.IsNaN(randomFloat))
            {
                randomFloat = BitConverter.ToSingle(buffer, 0);
            }

            if (randomFloat < 0f)
            {
                randomFloat = (float) Math.Sqrt(-1 * randomFloat) * -1;
            }
            else
            {
                randomFloat = (float) Math.Sqrt(randomFloat);    
            }

            return randomFloat;
        }
    }
}