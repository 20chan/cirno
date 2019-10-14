using System;

namespace cirno {
    [System.Diagnostics.DebuggerDisplay("({X}, {Y})")]
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

        public float Distance(Vector point)
        {
            return (float)Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
        }

        public float Magnitude {
            get => X * X + Y * Y;
        }

        public float Length {
            get => (float)Math.Sqrt(Magnitude);
        }

        public Vector Round(int digits)
        {
            return new Vector((float)Math.Round(X, digits), (float)Math.Round(Y, digits));
        }

        public float Cross(Vector other) {
            return X * other.Y - Y * other.X;
        }

        public float Dot(Vector other) {
            return X * other.X + Y * other.Y;
        }

        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b) {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static Vector operator *(Vector v, float n) {
            return new Vector(v.X * n, v.Y * n);
        }

        public static Vector operator *(float n, Vector v) {
            return new Vector(v.X * n, v.Y * n);
        }

        public static Vector operator /(Vector v, float n) {
            return new Vector(v.X / n, v.Y / n);
        }
    }
}
