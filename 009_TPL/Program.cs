namespace TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task<int> task = Task.Run<int>(new Func<int>(GetValue));
            //Task<int> task1 = task.ContinueWith<int>(Increment);
            //Task<int> task2 = task1.ContinueWith<int>(Increment);
            //Task<int> task3 = task2.ContinueWith<int>(Increment);
            //Task<int> task4 = task3.ContinueWith<int>(Increment);
            //Task<int> task5 = task4.ContinueWith<int>(Increment);
            //task5.ContinueWith(ShowResult);

            task.ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(ShowResult);

            Console.ReadKey();
        }

        private static int GetValue()
        {
            return 6;
        }

        private static int Increment(Task<int>a)
        {
            Console.WriteLine($"Continuation Task Id #{Task.CurrentId} Thread Id #{Thread.CurrentThread.ManagedThreadId}");
            int result = a.Result + 1;
            return result;
        }

        private static void ShowResult(Task<int> task)
        {
            Console.WriteLine($"Continuation Task Id #{Task.CurrentId} Thread Id #{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"The Result Of Asynchron Operation is {task.Result}");
        }
    }
}
