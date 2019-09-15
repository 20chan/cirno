namespace cirno.Geometry {
    public class Line : IShape {
        public Vector P1, P2;

        public Line(Vector p1, Vector p2) {
            P1 = p1;
            P2 = p2;
        }

        public object Clone() {
            return new Line(P1, P2);
        }
    }
}
