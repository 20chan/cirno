using System;

namespace cirno {
    public struct Vector {
        public float X, Y;

        public Vector(float x, float y) {
            X = x;
            Y = y;
        }

        public override int GetHashCode() {
            unchecked {
                var hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj) {
            if (!(obj is Vector v)) {
                return false;
            }

            return Equals(v);
        }

        public bool Equals(Vector other, float tolerance = 0.0001f) {
            return Math.Abs(X - other.X) < tolerance
                && Math.Abs(Y - other.Y) < tolerance;
        }

        public float Cross(Vector other) {
            return X * other.Y - Y * other.X;
        }

        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
        public static Vector operator -(Vector a, Vector b) {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
    }
}
