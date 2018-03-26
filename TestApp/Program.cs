namespace TestApp
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            //_06_01_Pattern.PatternTest.Test();

            //Console.ReadLine();
        }

        public static async Task Test1()
        {
            await Task.Run(() =>
             {
                 Console.WriteLine("Test1");
             });
        }
        public static async Task Test2()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Test2");
            });
        }
    }
}
