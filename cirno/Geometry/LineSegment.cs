namespace cirno.Geometry {
    public class LineSegment : IShape {
        public Vector P1, P2;

        public LineSegment(Vector p1, Vector p2) {
            P1 = p1;
            P2 = p2;
        }

        public object Clone() {
            return new LineSegment(P1, P2);
        }
    }
}
