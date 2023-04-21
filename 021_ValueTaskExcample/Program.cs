namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int res = Sum(-1, 8).Result;
            Console.WriteLine(res);

            Console.ReadKey();
        }

        private static ValueTask<int> Sum(int x, int y)
        {
            if (x == 0)
            {
                return new ValueTask<int>(y);
            }
            else if (y == 0)
            {
                return new ValueTask<int>(x);
            }
            else if (x == 0 && y == 0)
            {
                return new ValueTask<int>(0);
            }
            else
            {
                return new ValueTask<int>(Task.Run(() => { return x + y; }));
            }
        }
    }
}