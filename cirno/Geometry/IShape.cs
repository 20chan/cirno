using System;

namespace cirno.Geometry {
    public interface IShape : ICloneable
    {
        float Distance(IShape other);
        Vector GetClosestPoint(Vector point);
    }
}
