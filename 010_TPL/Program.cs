namespace TPL
{
    internal class Program
    {
        private static Random random = new Random();
        private static void Main(string[] args)
        {
            TaskFactory taskFactory = new TaskFactory();

            Task<double> t1 = taskFactory.StartNew(() => { return Calculation(1); });
            Task<double> t2 = taskFactory.StartNew(() => { return Calculation(2); });
            Task<double> t3 = taskFactory.StartNew(() => { return Calculation(3); });
            Task<double> t4 = taskFactory.StartNew(() => { return Calculation(4); });
            Task<double> t5 = taskFactory.StartNew(() => { return Calculation(5); });
            Task<double> t6 = taskFactory.StartNew(() => { return Calculation(6); });

            taskFactory.ContinueWhenAll(new Task[] { t1, t2, t3, t4, t5, t6 },
                complatedTask =>
                {
                    double sum = 0;

                    foreach (Task<double> item in complatedTask)
                    {
                        sum += item.Result;
                    }

                    Console.WriteLine($"The result {sum:N}");
                });

            Console.ReadKey();
        }

        private static double Calculation(int n)
        {
            double res = 0.0;

            for (int i = 0; i < 10; i++)
            {
                res += (i * random.Next(1, n) / (n * 2) * n);
            }

            return res;
        }
    }
}
