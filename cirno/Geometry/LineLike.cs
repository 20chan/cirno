using System;
using System.Collections.Generic;
using System.Text;

namespace cirno.Geometry {
    public abstract class LineLike : IShape {
        public Point P1, P2;

        public LineLike(Point p1, Point p2) {
            P1 = p1;
            P2 = p2;
        }

        public bool Parallel(Line other, float tolerance = 0.0001f) {
            return (P1 - P2).Cross(other.P1 - other.P2) < tolerance;
        }

        public bool Perpendicular(LineLike other, float tolerance = 0.0001f) {
            return (P1 - P2).Dot(other.P1 - other.P2) < tolerance;
        }

        /// <summary>left: -1, on: 0, right: 1</summary>
        public int GetSideOf(Point point) {
            return -1 * Math.Sign((P2.X - P1.X) * (point.Y - P1.Y) - (P2.Y - P1.Y) * (point.X - P1.X));
        }

        public Point GetPerpendicularFootOn(Point point) {
            // https://www.youtube.com/watch?v=TPDgB6136ZE
            var ap = point - P1;
            var b = P2 - P1;
            var bb = b / b.Length;
            var af = ap.Dot(bb) * bb;
            var f = P1 + af;

            return f;
        }

        public Vector GetPerpendicular(Point point) {
            var foot = GetPerpendicularFootOn(point);
            Point p = point + 2 * (foot - point);
            return new Vector(p.X, p.Y);
        }

        public abstract object Clone();
    }
}
