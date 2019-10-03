using System;

namespace cirno.Geometry {
    public class LineSegment : LineLike {
        public LineSegment(Point p1, Point p2) : base(p1, p2) {
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
            if (!(obj is LineSegment l)) {
                return false;
            }

            return Equals(l);
        }

        public bool Equals(LineSegment other, float tolerance = 0.0001f) {
            return (Close(P1, other.P1) && Close(P2, other.P2))
                || (Close(P1, other.P2) && Close(P2, other.P1));

            bool Close(Point a, Point b) {
                return Math.Abs(a.X - b.X) < tolerance && Math.Abs(a.Y - b.Y) < tolerance;
            }
        }

        public override object Clone() {
            return new LineSegment(P1, P2);
        }
    }
}
