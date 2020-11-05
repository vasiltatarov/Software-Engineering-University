namespace Operations
{
    public class MathOperations : IMathOperations
    {
        public int Add(int x, int y) => x + y;

        public double Add(double x, double y, double z) => x + y + z;

        public decimal Add(decimal x, decimal y, decimal z) => x + y + z;
    }
}
