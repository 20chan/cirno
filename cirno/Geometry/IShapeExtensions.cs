namespace cirno.Geometry {
    public static class IShapeExtensions {
        public static bool Intersects(this IShape self, IShape other) {
            return Intersections.Intersects(self, other);
        }

        public static bool TryGetIntersects(this IShape self, IShape other, out Vector[] intersects) {
            return Intersections.TryGetIntersects(self, other, out intersects);
        }
    }
}
