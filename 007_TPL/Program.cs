namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task task = new Task(new Action<object>(OperationAsync), "Hello World");
            Task continuation = task.ContinueWith(Continuation);

            Console.WriteLine($"Application status - {continuation.Status}");
            task.Start();

            Console.ReadKey();
        }

        private static void OperationAsync(object arg)
        {
            Console.WriteLine($"Task # {Task.CurrentId} started insade Thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Argument value - {arg.ToString()}");

            Console.WriteLine($"Task # {Task.CurrentId} Finished insade Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Continuation(Task task)
        {
            Console.WriteLine($"Continuation # {Task.CurrentId} Worked insade Thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Parameter Task - {task.AsyncState}");

            Console.WriteLine($"Immediately after completing the task.");
        }
    }
}
