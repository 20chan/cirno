using System;

namespace cirno.Geometry {
    public interface IShape : ICloneable {
        float Distance(IShape other);
        float Distance(Vector point);
        Vector GetClosestPoint(Vector point);
    }
}
