using System;

namespace cirno {
    public struct Point {
        public float X, Y;

        public Point(float x, float y) {
            X = x;
            Y = y;
        }

        public override int GetHashCode() {
            unchecked {
                var hash = 11;
                hash = hash * 17 + X.GetHashCode();
                hash = hash * 17 + Y.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj) {
            if (!(obj is Point p)) {
                return false;
            }

            return Equals(p);
        }

        public bool Equals(Point other, float tolerance = 0.0001f) {
            return Math.Abs(X - other.X) < tolerance
                && Math.Abs(Y - other.Y) < tolerance;
        }

        public static Point operator +(Point p, Vector v) {
            return new Point(p.X + v.X, p.Y + v.Y);
        }

        public static Vector operator -(Point p, Vector v) {
            return new Vector(p.X - v.X, p.Y - v.Y);
        }

        public static Vector operator -(Point p, Point other) {
            return new Vector(p.X - other.X, p.Y - other.Y);
        }
    }
}