using System;

namespace cirno.Geometry {
    public interface IShape : ICloneable
    {
        float Distance(IShape shape);
    }
}
