using System.Security.Cryptography;

namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task task = Task.Run(() => Method());

            //task.ContinueWith((t)=>Continuation(t),TaskContinuationOptions.ExecuteSynchronously);
            task.ContinueWith((t) => Continuation(t), TaskContinuationOptions.RunContinuationsAsynchronously);

            Console.ReadKey();
        }

        private static void Method()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"Task #{Task.CurrentId} Completed method insade Thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(new string ('_',80));
        }

        private static void Continuation(Task task)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Id for Continoation Task - {Task.CurrentId}");
            Console.WriteLine($"Continuation completed insade Thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine();
        }
    }
}
