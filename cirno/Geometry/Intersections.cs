using System;

namespace cirno.Geometry {
    internal static class Intersections {
        public static bool Intersects(IShape a, IShape b) {
            return TryGetIntersects(a, b, out _);
        }

        public static bool TryGetIntersects(IShape a, IShape b, out Vector[] intersects) {
            if (a is Line la) {
                if (b is Line lb) {
                    return LineLine(la, lb, false, false, out intersects);
                }
                else if (b is LineSegment sb) {
                    return LineLine(la, sb, false, true, out intersects);
                }
            }
            else if (a is LineSegment sa) {
                if (b is Line lb) {
                    return LineLine(sa, lb, true, false, out intersects);
                }
                else if (b is LineSegment sb) {
                    return LineLine(sa, sb, true, true, out intersects);
                }
            }

            throw new NotImplementedException();
        }

        private static bool LineLine(LineLike a, LineLike b, bool aSeg, bool bSeg, out Vector[] intersects) {
            // https://en.wikipedia.org/wiki/Line–line_intersection

            var x1 = a.P1.X;
            var y1 = a.P1.Y;
            var x2 = a.P2.X;
            var y2 = a.P2.Y;
            var x3 = b.P1.X;
            var y3 = b.P1.Y;
            var x4 = b.P2.X;
            var y4 = b.P2.Y;

            var nume0 = x1 * y2 - y1 * x2;
            var nume1 = x3 * y4 - y3 * x4;

            var xNume = nume0 * (x3 - x4) - (x1 - x2) * nume1;
            var yNume = nume0 * (y3 - y4) - (y1 - y2) * nume1;

            // equals to (a.P1 - a.P2).Cross(b.P1 - b.P2);
            var deno = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            var tNume = (x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4);
            var uNume = (x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3);

            if (deno == 0) {
                intersects = null;
                return false;
            }

            var t = tNume / deno;
            var u = -uNume / deno;

            if (aSeg) {
                if (t < 0 || 1 < t) {
                    intersects = default;
                    return false;
                }
            }
            if (bSeg) {
                if (u < 0 || 1 < u) {
                    intersects = default;
                    return false;
                }
            }

            intersects = new[] { new Vector(xNume / deno, yNume / deno) };
            return true;
        }
    }
}
