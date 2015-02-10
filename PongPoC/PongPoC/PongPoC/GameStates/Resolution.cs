namespace PongPoC.GameStates
{
    internal sealed class Resolution
    {
        public Resolution(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public override string ToString()
        {
            return X + " x " + Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Resolution && Equals((Resolution) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }

        private bool Equals(Resolution other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}