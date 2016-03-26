

namespace SeanStandardScript
{
    public struct IntVector2
    {
        public int x, y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.x + b.x, a.y + b.y);
        }

        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.x - b.x, a.y - b.y);
        }

        public static IntVector2 operator *(IntVector2 a, int b)
        {
            return new IntVector2(a.x*b, a.y*b);
        }

        public static bool operator ==(IntVector2 a, IntVector2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(IntVector2 a, IntVector2 b)
        {
            return !a.Equals(b);
        }

        public bool Equals(IntVector2 other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IntVector2 && Equals((IntVector2) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x*397) ^ y;
            }
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
    }
}