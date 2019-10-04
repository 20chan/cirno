using System;

namespace cirno.Geometry {
    internal static class Intersections {
        public static bool Intersects(IShape a, IShape b) {
            return TryGetIntersects(a, b, out _);
        }

        public static bool TryGetIntersects(IShape a, IShape b, out Vector[] intersects) {
            switch (a) {
                case Line la when b is Line lb:
                    return LineLine(la, lb, false, false, out intersects);
                case Line la when b is LineSegment sb:
                    return LineLine(la, sb, false, true, out intersects);
                case LineSegment sa when b is Line lb:
                    return LineLine(sa, lb, true, false, out intersects);
                case LineSegment sa when b is LineSegment sb:
                    return LineLine(sa, sb, true, true, out intersects);
                case Circle ca when b is Circle cb:
                    return CircleCircle(ca, cb, out intersects);
                case Circle ca when b is Line lb:
                    return CircleLine(ca, lb, out intersects);
                case Line la when b is Circle cb:
                    return CircleLine(cb, la, out intersects);
                case Circle ca when b is LineSegment sb:
                    return CircleSegment(ca, sb, out intersects);
                case LineSegment sa when b is Circle cb:
                    return CircleSegment(cb, sa, out intersects);
                default:
                    throw new NotImplementedException();
            }
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

            intersects = new[] {new Vector(xNume / deno, yNume / deno)};
            return true;
        }

        private static bool CircleCircle(Circle c1, Circle c2, out Vector[] intersects) {
            // Read: https://www.xarg.org/2016/07/calculate-the-intersection-points-of-two-circles/

            if (c1.Equals(c2)) {
                intersects = default;
                return true;
            }

            // Distance computation is susceptible to errors
            // TODO consider using a hypot implementation
            var difX = c1.Center.X - c2.Center.X;
            var difY = c1.Center.Y - c2.Center.Y;
            var dist = Math.Sqrt(difX * difX + difY * difY);

            if (dist <= c1.Radius + c2.Radius && dist >= Math.Abs(c2.Radius - c1.Radius)) {
                var ex = (c2.Center.X - c1.Center.X) / dist;
                var ey = (c2.Center.Y - c1.Center.Y) / dist;

                var x = (c1.Radius * c1.Radius - c2.Radius * c2.Radius + dist * dist) / (2 * dist);
                var y = Math.Sqrt(c1.Radius * c1.Radius - x * x);

                var intersection1 = new Vector {
                    X = (float) (c1.Center.X + x * ex - y * ey),
                    Y = (float) (c1.Center.Y + x * ey + y * ex)
                };

                var intersection2 = new Vector {
                    X = (float) (c1.Center.X + x * ex + y * ey),
                    Y = (float) (c1.Center.Y + x * ey - y * ex)
                };

                intersects = intersection1.Equals(intersection2)
                    ? new[] {intersection1}
                    : new[] {intersection1, intersection2};
                return true;
            }

            // No intersection, far outside or one circle within the other
            intersects = default;
            return false;
        }

        public static bool CircleLine(Circle c, Line l, out Vector[] intersects) {
            var dx = l.P2.X - l.P1.X;
            var dy = l.P2.Y - l.P1.Y;
            var dr = Math.Sqrt(dx * dx + dy * dy);
            var D = l.P1.X * l.P2.Y - l.P2.X * l.P1.Y;
            var discriminant = c.Radius * c.Radius * dr * dr - D * D;

            var signOf = new Func<float, int>((number) => { return number < 0 ? -1 : 1; });

            switch (discriminant) {
                case var d when d < 0:
                    intersects = default;
                    return false;
                case 0:
                    var point = new Vector {
                        X = (float) ((D * dy + signOf(dy) * dx * Math.Sqrt(discriminant)) / (dr * dr)),
                        Y = (float) ((-D * dx + Math.Abs(dy) * Math.Sqrt(discriminant)) / (dr * dr))
                    };
                    intersects = new Vector[] {point};
                    return true;
                default:
                    var point1 = new Vector {
                        X = (float) ((D * dy + signOf(dy) * dx * Math.Sqrt(discriminant)) / (dr * dr)),
                        Y = (float) ((-D * dx + Math.Abs(dy) * Math.Sqrt(discriminant)) / (dr * dr))
                    };
                    var point2 = new Vector {
                        X = (float) ((D * dy - signOf(dy) * dx * Math.Sqrt(discriminant)) / (dr * dr)),
                        Y = (float) ((-D * dx - Math.Abs(dy) * Math.Sqrt(discriminant)) / (dr * dr))
                    };
                    intersects = new Vector[] {point1, point2};
                    return true;
            }
        }

        public static bool CircleSegment(Circle circle, LineSegment segment, out Vector[] intersects) {
            // See https://stackoverflow.com/questions/1073336/circle-line-segment-collision-detection-algorithm
            
            var d = segment.P2 - segment.P1;
            var f = segment.P1 - circle.Center;
            var a = d.Dot(d);
            var b = 2 * f.Dot(d);
            var c = f.Dot(f) - circle.Radius * circle.Radius;

            var discriminant = b * b - 4 * a * c;

            if (discriminant < 0) {
                intersects = default;
                return false;
            }

            discriminant = (float) Math.Sqrt(discriminant);

            var t1 = (-b - discriminant) / (2 * a);
            var t2 = (-b + discriminant) / (2 * a);

            // 3x HIT cases:
            //          -o->             --|-->  |            |  --|->
            // Impale(t1 hit,t2 hit), Poke(t1 hit,t2>1), ExitWound(t1<0, t2 hit), 

            // 3x MISS cases:
            //       ->  o                     o ->              | -> |
            // FallShort (t1>1,t2>1), Past (t1<0,t2<0), CompletelyInside(t1<0, t2>1)

            if (t1 >= 0 && t1 <= 1) {
                // t1 is the intersection, and it's closer than t2
                // (since t1 uses -b - discriminant)
                // Impale, Poke
                var point1 = new Vector {
                    X = (1 - t1) * segment.P1.X + t1 * segment.P2.X,
                    Y = (1 - t1) * segment.P1.Y + t1 * segment.P2.Y
                };
                var point2 = new Vector {
                    X = (1 - t2) * segment.P1.X + t2 * segment.P2.X,
                    Y = (1 - t2) * segment.P1.Y + t2 * segment.P2.Y
                };

                intersects = point1.Equals(point2) ? new[] {point1} : new[] {point1, point2};
                return true;
            }

            // here t1 didn't intersect so we are either started
            // inside the sphere or completely past it
            if (t2 >= 0 && t2 <= 1) {
                // ExitWound
                var point = new Vector {
                    X = (1 - t2) * segment.P1.X + t2 * segment.P2.X,
                    Y = (1 - t2) * segment.P1.Y + t2 * segment.P2.Y
                };
                intersects = new []{point};
                return true;
            }

            // no intn: FallShort, Past, CompletelyInside
            intersects = default;
            return false;
        }
    }
}