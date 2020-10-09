using System;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //TPLOverview.Start();
            var task = AsyncAwaiTest.StartAsync();
            var process_messages_task = AsyncAwaiTest.ProcessDataTestAsync();

            Console.WriteLine("Тестовая задача запущена и мы её ждём!..");

            Task.WaitAll(task, process_messages_task);

            Console.WriteLine("Главный поток работу закончил!");
            Console.ReadLine();
        }

      
    }
}
