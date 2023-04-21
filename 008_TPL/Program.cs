namespace TPL
{
    internal class Programm
    {
        private static void Main(string[] args)
        {
            int a = 5, b = 6;
            Task<int> task = Task.Run<int>(() => Calc(a, b));
            
            task.ContinueWith(Continuation);
            Console.ReadKey();
        }

        private static int Calc(int a, int b)
        {
            Console.WriteLine($"Task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
            return a + b;
        }

        private static void Continuation(Task<int> task)
        {
            Console.WriteLine($"Continuation Task Id - {Task.CurrentId}. Thread Id - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"The resul of asynchron operation {task.Result}");
        }
    }
}
