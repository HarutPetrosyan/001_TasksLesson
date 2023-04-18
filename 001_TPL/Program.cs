namespace TPL
{
    internal class Program
    {
        public static void Main()
        {
            Action threadOutput = new Action(ThreadOutput);

            Task task= new Task(threadOutput);
            task.Start();
            MainOutput();

            TaskFactory taskFactory= new TaskFactory();
            taskFactory.StartNew(threadOutput);
            MainOutput();

            Task.Run(threadOutput);
            MainOutput();

            task = new Task(threadOutput);
            task.RunSynchronously();
            MainOutput();
        }

        private static void ThreadOutput()
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write("*");
                Thread.Sleep(75);
            }
        }

        private static void MainOutput()
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
                Thread.Sleep(75);
            }
        }
    }
}