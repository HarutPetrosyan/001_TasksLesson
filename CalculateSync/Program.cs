namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int number = 13;
            var result=CalculateFactorialAsync(number);
            result.ContinueWith(x => Console.WriteLine($"The Result = {x.Result}"));

            while (true)
            {
                Console.Write('*');
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }

        private static Task<long> CalculateFactorialAsync(int number) 
        {
            return Task.Run( () => CalculateFactorial(number));
        }

        private static long CalculateFactorial(int number)
        {
            Thread.Sleep(500);

            if (number == 1)
            {
                return 1;
            }

            return CalculateFactorial(number - 1)*number;
        }
    }
}
