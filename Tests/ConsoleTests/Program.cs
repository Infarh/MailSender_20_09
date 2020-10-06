using System;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTests.Start();
            CriticalSectionTests.Start();

            Console.WriteLine("Главный поток работу закончил!");
            Console.ReadLine();
        }
    }
}
