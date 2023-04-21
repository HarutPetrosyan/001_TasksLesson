namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CalculateAndShowAsync(5).GetAwaiter().GetResult();

            Console.ReadKey();
        }

        private static ValueTask CalculateAndShowAsync(int cailing)
        {
            if(cailing<0)
            {
                return new ValueTask();
            }
            else
            {
                return new ValueTask(Task.Run(() =>
                {
                    Calculator(cailing);
                }));
            }
        }

        private static void Calculator(int cailing)
        {
            int sum = 0;

            for (int i = 0; i <= cailing; i++)
            {
                sum += i;
            }

            Console.WriteLine($"The result - {sum}. Find in Task #{Task.CurrentId}, In Thread #{Thread.CurrentThread.ManagedThreadId}" );
        }
    }
}
