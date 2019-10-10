using System;

namespace cirno.Geometry {
    public class Circle : IShape {
        public Vector Center { get; set; }
        public float Radius { get; set; }
        
        public Circle(Vector center, float radius) {
            Center = center;
            Radius = radius;
        }

        public bool Concentric(Circle other, float tolerance = 0.0001f) {
            return Center.Equals(other.Center, tolerance);
        }
        
        public override int GetHashCode() {
            unchecked {
                var hash = 17;
                hash = hash * 23 + Center.GetHashCode();
                hash = hash * 23 + Radius.GetHashCode();
                return hash;
            }
        }
        
        public override bool Equals(object obj) {
            if (!(obj is Circle circle)) {
                return false;
            }

            return Equals(circle);
        }

        public bool Equals(Circle other, float tolerance = 0.0001f) {
            return Center.Equals(other.Center, tolerance) && Math.Abs(Radius - other.Radius) < tolerance;
        }

        public object Clone() {
            return new Circle(Center, Radius);
        }

        public float Distance(IShape shape)
        {
            throw new NotImplementedException();
        }
    }
}