namespace TPL
{
    internal class Program
    {
        private static bool flag = false;
        private static void Main(string[] args)
        {
            Task<int> task1 = new Task<int>(new Func<int>(GetIntResult));
            task1.Start();
            Console.WriteLine($"The result of asynchron operation (int) #1 - {task1.Result}");

            Thread.Sleep(1000);

            TaskFactory taskFactory= new TaskFactory();
            Task<bool> task2=taskFactory.StartNew(new Func<bool>(GetBoolResult));
            Console.WriteLine($"The result of asynchron operation (bool) #2 - {task2.Result}");

            Thread.Sleep(1000);

            Task<bool> task3= Task.Run(new Func<bool>(GetBoolResult));
            Console.WriteLine($"The result of asynchron operation (bool) #3 - {task3.Result}");
        }

        private static int GetIntResult()
        {
            return 1;
        }

        private static bool GetBoolResult()
        {
            if(flag)
            {
                flag= false;
                return true;
            }
            else
            {
                flag= true;
                return false;
            }
        }
    }
}
