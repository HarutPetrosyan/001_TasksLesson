namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task[] tasks = new Task[] 
            {
                new Task(DoSomething,1000),
                new Task(DoSomething,800),
                new Task(DoSomething,2000),
                new Task(DoSomething,1000),
                new Task(DoSomething,3500),
            };

            Console.WriteLine("Method Main Performed");
            foreach (Task item in tasks)
            {
                item.Start();
            }

            Console.WriteLine("Method Main Waited");
            //foreach (Task item in tasks)
            //{
            //    item.Wait();
            //}
            Task.WaitAll(tasks);

            Console.WriteLine("Method Main continued your work");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main({i})");
            }
        }

        private static void DoSomething(object sleepTime)
        {
            Console.WriteLine($" Task #{Task.CurrentId} Started insade thread {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep((int)sleepTime);

            Console.WriteLine($" Task #{Task.CurrentId} Finished insade thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
