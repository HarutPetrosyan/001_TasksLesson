﻿namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int salary = 25000;
            ValueTask<double> valueTask = GetIndexing(salary);

            while (!valueTask.IsCompleted)
            {
                Console.Write('*');
                Thread.Sleep(200);
            }

            Task<double> task=valueTask.AsTask();

            task.ContinueWith(t => Console.WriteLine($"\nIndexing Salery {salary} = {t.Result}%"));

            Console.ReadKey();
        }

        private static ValueTask<double> GetIndexing(double salary)
        {
            Thread.Sleep(1000);

            if(salary<=0)
            {
                return new ValueTask<double>(0);
            }
            else if (salary > 50000)
            {
                return new ValueTask<double>(0);
            }
            else if(salary==50000)
            {
                return new ValueTask<double>(0.1);
            }
            else
            {
                return new ValueTask<double>(Task.Run(() =>
                {
                    double index = 0.0;
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(500);
                        index += 0.1;
                    }
                    return index;
                }));
            }
        }
    }
}
