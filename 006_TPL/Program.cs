namespace TPL
{
    public struct Box
    {
        public int x;
        public int y;
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            int a = 3, b = 5;
            Box box;

            box.y = a;
            box.x = b;

            Task<int> calc = new Task<int>(Calc, box);
            calc.Start();

            Console.WriteLine($"Sum of numbers : {calc.Result}");
            Console.WriteLine(new string('-', 80));

            Task<int> lambda = new Task<int>(() => Calc(a, 6));
            lambda.Start();

            Console.WriteLine($"Sum of numbers : {lambda.Result}");
            Console.WriteLine(new string('-', 80));

            Task<int> task1 = Task<int>.Run<int>(() =>
            {
                int a1 = 7;
                int b1 = 8;
                return Calc(a1, b1);
            });

            Console.WriteLine($"Sum of Numbers : {task1.Result}");

            Task.Run(() => ShowSelfParameters(25, 65, "Hello", 4.5,new object(), box, new Program(), lambda));
            Console.ReadKey();
        }

        private static int Calc(object arg)
        {
            Box box = (Box)arg;
            return box.x + box.y;
        }

        private static int Calc(int a, int b)
        {
            return a + b;
        }

        private static void ShowSelfParameters(int a, int b,string name,double k,object f, Box box, Program program, dynamic task)
        {
            Console.WriteLine(new string('-',80));

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(name);
            Console.WriteLine(k);
            Console.WriteLine(f);
            Console.WriteLine(box.y+""+box.x);
            Console.WriteLine(program.GetType().ToString());
            Console.WriteLine(task);

            Console.WriteLine(new string('-', 80));
        }
    }
}
