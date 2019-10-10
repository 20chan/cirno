using System;

namespace cirno.Tests.Geometry
{
    public static class TestHelpers
    {
        public static float NextFloat(this Random random)
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);
            return BitConverter.ToSingle(buffer,0);
        }
    }
}