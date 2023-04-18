namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"Task Id method Main : {Task.CurrentId ?? -1}");
            Console.WriteLine($"Thred Id Method Main : {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(new string('-', 80));

            Task task = new Task(new Action(DoSomething), TaskCreationOptions.PreferFairness| TaskCreationOptions.LongRunning);

            task.Start();
            Thread.Sleep(50);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("           Method Main performed");
                Thread.Sleep(100);
            }

            Console.ReadKey();
        }

        private static void DoSomething()
        {
            Console.WriteLine($"Task Id Method DoSomethong : {Task.CurrentId}");
            Console.WriteLine($"Thread Id method DoSomething : {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine(new string('-', 80));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"                 Task Complited");
                Thread.Sleep(100);
            }

            Console.WriteLine($"Task Finished insade Thread : {Thread.CurrentThread.ManagedThreadId}.");
        }
    }
}