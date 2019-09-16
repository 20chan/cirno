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

        public abstract object Clone();
    }
}
