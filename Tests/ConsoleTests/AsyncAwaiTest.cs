using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTests
{
    static class AsyncAwaiTest
    {
        private static void PrintThreadInfo(string Message = "")
        {
            var current_thread = Thread.CurrentThread;
            Console.WriteLine("Thread id:{0} Task id: {1} {2}", current_thread.ManagedThreadId, Task.CurrentId, Message);
        }

        public static async Task StartAsync()
        {
            Console.WriteLine("Запуск асинхронного метода выполняется синхронно!!!");
            PrintThreadInfo("При входе в метод StartAsync");

            //var result_task = GetStringResultAsync();
            //var result = await result_task;
            //var result = await GetStringResultAsync();
            var result = await GetStringResultRealyAsync();

            Console.WriteLine("Был получен результат {0}", result);
            PrintThreadInfo("При печати результата");

            var result2 = await GetStringResultRealyAsync();

            Console.WriteLine("Был получен результат {0}", result2);
            PrintThreadInfo("При печати результата");

            for (var i = 0; i < 10; i++)
            {
                var result3 = await GetStringResultRealyAsync();

                Console.WriteLine("Был получен результат {0}", result3);
                PrintThreadInfo("При печати результата");
            }
        }

        private static async Task<string> GetStringResultAsync()
        {
            PrintThreadInfo("В псевдоасинхронном методе");
            return DateTime.Now.ToString();
            //return Task.FromResult(DateTime.Now.ToString());
        }

        private static Task<string> GetStringResultRealyAsync()
        {
            PrintThreadInfo("В начале асинхронного метода");
            return Task.Run(() =>
            {
                PrintThreadInfo("Внутри асинхронного метода");
                return DateTime.Now.ToString();
            });
        }

        public static async Task ProcessDataTestAsync()
        {
            var messages = Enumerable.Range(1, 50).Select(i => $"Message {i}");//.ToArray();

            var tasks = messages.Select(msg => Task.Run(() => LowSpeedPrinter(msg)));

            Console.WriteLine(">>> Подготовка к запуску обработки сообщений...");

            var runing_tasks = tasks.ToArray();

            Console.WriteLine(">>> Задачи созданы");

            await Task.WhenAll(runing_tasks);

            Console.WriteLine(">>> Обработка всех сообщений завершена");
        }

        private static void LowSpeedPrinter(string msg)
        {
            Console.WriteLine(">>> [Thread id:{1}] Начинаю обработку {0}...", msg, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
            Console.WriteLine(">>> [Thread id:{1}] Сообщение {0} обработано!", msg, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
