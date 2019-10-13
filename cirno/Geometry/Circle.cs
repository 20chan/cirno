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

        public Vector GetClosestPoint(Vector point)
        {
            // idea :
            // the line strikes through the center of the center point will intersects the closest point

            // get the linear line properties
            // line formula: y = Mx + C
            double M = (point.Y - Center.Y) / (point.X - Center.X);
            double Yc = point.Y - M * point.X;

            // get the circle properties
            // circle formula: (x-A)^2 + (y-B)^2 = R^2
            double A = Center.X;
            double B = Center.Y;
            double R = Radius;

            // this two formula intersection will give quadratic formula
            // (x - A)^2 + (M*x + Yc - B)^2 = R^2
            // (M^2 + 1)*x^2 + (2M(Yc - B) -2A)*x + ((Yc - B)^2 + A^2 - R^2) = 0 
            double a = Math.Pow(M, 2) + 1;
            double b = 2 * M * (Yc - B) - 2 * A;
            double c = Math.Pow(Yc - B, 2) + Math.Pow(A, 2) - Math.Pow(R, 2);

            // get solution X
            // using Determinant, D = b^2 - 4*a*c
            // using x = -b +/- sqrt(D) / 2a
            double D = b * b - 4 * a * c;

            // this Quardratic always comes with 2 solutions
            double x1 = (-b - Math.Sqrt(D)) / (2 * a);
            double y1 = M * x1 + Yc;
            Vector v1 = new Vector((float)x1, (float)y1);

            double x2 = (-b + Math.Sqrt(D)) / (2 * a);
            double y2 = M * x2 + Yc;
            Vector v2 = new Vector((float)x2, (float)y2);

            // get distance
            double d1 = point.Distance(v1);
            double d2 = point.Distance(v2);

            // compare and return the closest one
            return d1 < d2 ? v1 : v2;
        }

        public float Distance(Vector point)
        {
            return point.Distance(GetClosestPoint(point));
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
    }
}