using System;

namespace cirno.Geometry {
    public class Line : IShape {
        public Vector P1, P2;

        public Line(Vector p1, Vector p2) {
            P1 = p1;
            P2 = p2;
        }

        public override int GetHashCode() {
            unchecked {
                var hash = 17;
                hash = hash * 31 + P1.GetHashCode();
                hash = hash * 31 + P2.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj) {
            if (!(obj is Line l)) {
                return false;
            }

            return Equals(l);
        }

        public bool Equals(Line other, float tolerance = 0.0001f) {
            if (!Parallel(other, tolerance)) {
                return false;
            }

            if (P1.Equals(other.P1) || P1.Equals(other.P2)
                || P2.Equals(other.P1) || P2.Equals(other.P2)) {
                return true;
            }

            return Parallel(new Line(P1, other.P1), tolerance);
        }

        public bool Parallel(Line other, float tolerance = 0.0001f) {
            return (P1 - P2).Cross(other.P1 - other.P2) < tolerance;
        }

        public object Clone() {
            return new Line(P1, P2);
        }
    }
}
