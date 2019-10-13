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

            // get the line properties
            float M = (point.Y - Center.Y) / (point.X - Center.X);
            float Yc = point.Y - M * point.X;

            // get the circle properties
            float A = Center.X;
            float B = Center.Y;
            float R = Radius;

            // circle formula: (x-A)^2 + (y-B)^2 = R^2
            // line formula: y = Mx + C
            // this two formula intersection will give quadratic formula
            // (M^2 + 1)*x^2 + (2M(Yc - 1) -2)*x + ((C - 1)^2 -1 - R^2) = 0 

            float a = M * M + 1;
            float b = 2 * M * (Yc - B) - 2 * A;
            float c = (Yc + B) * (Yc + B) + A * A - R * R;

            // get solution X
            // using Determinant d = b^2 - 4*a*c
            // using x = -b +/- sqrt(d) / 2a
            float D = b * b - 4 * a * c;

            // this Quardratic always comes with 2 solutions
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double y1 = M * x1 + Yc;
            Vector v1 = new Vector((float)x1, (float)y1);

            double x2 = (-b + Math.Sqrt(D)) / (2 * a);
            double y2 = M * x1 + Yc;
            Vector v2 = new Vector((float)x2, (float)y2);

            // get distance
            double d1 = Math.Sqrt(Math.Pow(v1.X - point.X, 2) + Math.Pow(v1.Y - point.Y, 2));
            double d2 = Math.Sqrt(Math.Pow(v2.X - point.X, 2) + Math.Pow(v2.Y - point.Y, 2));

            // compare and return the closest one
            return d1 < d2 ? v1 : v2;
        }

        public float Distance(Vector point)
        {
            // idea :
            // the line strikes through the center of the center point will intersects the closest point
            // same as how we get the closest point.

            // get the line properties
            float M = (point.Y - Center.Y) / (point.X - Center.X);
            float Yc = point.Y - M * point.X;

            // get the circle properties
            float A = Center.X;
            float B = Center.Y;
            float R = Radius;

            // circle formula: (x-A)^2 + (y-B)^2 = R^2
            // line formula: y = Mx + C
            // this two formula intersection will give quadratic formula
            // (M^2 + 1)*x^2 + (2M(Yc - 1) -2)*x + ((C - 1)^2 -1 - R^2) = 0 

            float a = M * M + 1;
            float b = 2 * M * (Yc - B) - 2 * A;
            float c = (Yc + B) * (Yc + B) + A * A - R * R;

            // get solution X
            // using Determinant d = b^2 - 4*a*c
            // using x = -b +/- sqrt(d) / 2a
            float D = b * b - 4 * a * c;

            // this Quardratic always comes with 2 solutions
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double y1 = M * x1 + Yc;
            Vector v1 = new Vector((float)x1, (float)y1);

            double x2 = (-b + Math.Sqrt(D)) / (2 * a);
            double y2 = M * x1 + Yc;
            Vector v2 = new Vector((float)x2, (float)y2);

            // get distance
            double d1 = Math.Sqrt(Math.Pow(v1.X - point.X, 2) + Math.Pow(v1.Y - point.Y, 2));
            double d2 = Math.Sqrt(Math.Pow(v2.X - point.X, 2) + Math.Pow(v2.Y - point.Y, 2));

            // compare and return the closest one
            return d1 < d2 ? (float) d1 : (float) d2;
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