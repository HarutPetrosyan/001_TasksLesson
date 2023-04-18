namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task task = new Task(new Action(Method));

            Console.WriteLine($"{task.Status}");

            task.Start();

            Console.WriteLine($"{task.Status}");
            Thread.Sleep(1000);

            Console.WriteLine($"{task.Status}");
            Thread.Sleep(2000);

            Console.WriteLine($"{task.Status}");
            Thread.Sleep(1000);

            Console.ReadKey();
        }

        private static void Method()
        {
            Thread.Sleep(2000);
        }
    }
}
