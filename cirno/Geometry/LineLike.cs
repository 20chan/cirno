using System;
using System.Collections.Generic;
using System.Text;

namespace cirno.Geometry {
    public abstract class LineLike : IShape {
        public Vector P1, P2;

        public LineLike(Vector p1, Vector p2) {
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
        public int GetSideOf(Vector point) {
            return -1 * Math.Sign((P2.X - P1.X) * (point.Y - P1.Y) - (P2.Y - P1.Y) * (point.X - P1.X));
        }

        public Vector GetPerpendicularFootOn(Vector point) {
            // https://www.youtube.com/watch?v=TPDgB6136ZE
            var ap = point - P1;
            var b = P2 - P1;
            var bb = b / b.Length;
            var af = ap.Dot(bb) * bb;
            var f = af + P1;

            return f;
        }

        public Vector GetPerpendicular(Vector point) {
            var foot = GetPerpendicularFootOn(point);
            return point + 2 * (foot - point);
        }

        public abstract object Clone();

        public float Distance(IShape other) {
            throw new NotImplementedException();
        }

        public float Distance(Vector point) {
            var lineDistance = P1.Distance(P2);
            var aPointX = (P2.Y - P1.Y) * point.X;
            var bPointY = (P2.X - P1.X) * point.Y;
            var c = P2.X * P1.Y - P2.Y * P1.X;

            return Math.Abs(aPointX - bPointY + c) / lineDistance;
        }

        public Vector GetClosestPoint(Vector point) {
            var closestPoint = new Vector();
            var slope = GetSlopeOfLine();
            if (float.IsInfinity(slope))
            {
                closestPoint.X = P1.X;
                closestPoint.Y = point.Y;
            }
            else if(Math.Abs(slope) < 0.01f)
            {
                closestPoint.X = point.X;
                closestPoint.Y = P1.Y;
            }
            else
            {
                var yIntercept = P1.Y - slope * P1.X;
                var perpendicularSlope = -(1 / slope);
                var perpendicularYIntercept = point.Y - perpendicularSlope * point.X;
                var closestX = (perpendicularYIntercept - yIntercept) / (slope - perpendicularSlope);
                var closestY = slope * closestX + yIntercept;
                closestPoint.X = closestX;
                closestPoint.Y = closestY;
            }

            return closestPoint;
        }

        private float GetSlopeOfLine() {
            return (P2.Y - P1.Y) / (P2.X - P1.X);
        }
    }
}
