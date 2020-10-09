using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTests
{
    static class TPLOverview
    {
        public static void Start()
        {
            //new Thread(() =>
            //{
            //    while (true)
            //    {
            //        Console.Title = DateTime.Now.ToString();
            //        Thread.Sleep(100);
            //    }
            //})
            //{ IsBackground = true }.Start();

            //new Task(() =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine(DateTime.Now);
            //        Thread.Sleep(100);
            //    }
            //}).Start();

            //var task = new Task(() => {  });

            //var factorial = new MathTask(() => Factorial(10));
            //var sum = new MathTask(() => Sum(10));

            //factorial.Start();
            //sum.Start();

            //Console.WriteLine("Факториал {0}; сумма {1}", factorial.Result, sum.Result);

            Action<string> printer = str =>
            {
                Console.WriteLine("Сообщение [thread id:{1,2}]: {0} ", str, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            };

            printer("Hello World!");
            printer.Invoke("123");

            //var process_control = printer.BeginInvoke("QWE", result => { Console.WriteLine("Операция печати завершена"); }, 123);

            //var worker = new BackgroundWorker();
            //worker.DoWork += (sender, args) =>
            //{
            //    var w = (BackgroundWorker) sender;
            //    w.ReportProgress(100);
            //    w.CancelAsync();
            //    // Асинхронная операция
            //};
            //worker.ProgressChanged += (s, e) => Console.WriteLine("Прогресс {0}", e.ProgressPercentage);
            //worker.RunWorkerCompleted += (s, e) => Console.WriteLine("Завершено");
            //worker.RunWorkerAsync();

            /* ------------------------------------------ */

            //Parallel.Invoke(
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    () => Console.WriteLine("Ещё один метод..."));

            //Parallel.Invoke(
            //    new ParallelOptions { MaxDegreeOfParallelism = 2 },
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    () => Console.WriteLine("Ещё один метод..."));

            //Parallel.For(0, 100, i => printer(i.ToString()));
            //Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 2 }, i => printer(i.ToString()));
            //var result = Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (i, state) =>
            //{
            //    printer(i.ToString());
            //    if(i > 10)
            //        state.Break();
            //});
            //Console.WriteLine("Выполнено {0} итераций", result.LowestBreakIteration);

            var messages = Enumerable.Range(1, 500).Select(i => $"Message {i}");//.ToArray();

            //Parallel.ForEach(messages, message => printer(message));
            //Parallel.ForEach(messages, new ParallelOptions { MaxDegreeOfParallelism = 2 }, message => printer(message));

            //foreach (var message in messages.Where(msg => msg.EndsWith("0")))
            //    printer(message);

            //var cancellation = new CancellationTokenSource();
            ////cancellation.Token.ThrowIfCancellationRequested();
            //var messages_count = messages
            //   .AsParallel()
            //   .WithDegreeOfParallelism(2)
            //   .WithCancellation(cancellation.Token)
            //   .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //   .Where(msg =>
            //   {
            //       printer(msg);
            //       return msg.EndsWith("0");
            //   })
            //   .AsSequential()
            //   .Count();

            //var task = new Task(() => printer("ello World"));
            ////task.
            //task.Start();

            //var continuation_task = task.ContinueWith(
            //    t => Console.WriteLine("Зaдача {0} завершилась.", t.Id), 
            //    TaskContinuationOptions.OnlyOnRanToCompletion);
            //task.ContinueWith(t => { }, TaskContinuationOptions.OnlyOnFaulted);

            var printer_task = Task.Run(() => printer("Hello World!"));
            //var printer_task2 = Task.Factory.StartNew(obj => printer((string)obj), "Hello World!");

            printer_task.Wait(); // костыли! не рекомендуется к использованию из-за вероятности мёртвой блокировки

            //var result_task = new Task<int>(() =>
            //{
            //    Thread.Sleep(100);
            //    return 42;
            //});

            var result_task = Task.Run(() =>
            {
                Thread.Sleep(100);
                return 42;
            });

            var result_task2 = Task.Run(() =>
            {
                Thread.Sleep(500);
                return 13;
            });

            var result_task3 = Task.Run(() =>
            {
                Thread.Sleep(10);
                return 13;
            });

            var result = result_task.Result; // костыли! не рекомендуется к использованию из-за вероятности мёртвой блокировки
            //var result2 = result_task.Result;
            //var result3 = result_task.Result;
            //var result4 = result_task.Result;

            //result_task.Wait();

            Task.WaitAll(result_task, result_task2, result_task3); // костыли! не рекомендуется к использованию из-за вероятности мёртвой блокировки
            var index = Task.WaitAny(result_task, result_task2, result_task3); // костыли! не рекомендуется к использованию из-за вероятности мёртвой блокировки

        }

        private static void ParallelInvokeMethod()
        {
            Console.WriteLine("ThrID:{0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThrID:{0} - finished", Thread.CurrentThread.ManagedThreadId);
        }

        private static void ParallelInvokeMethod(string msg)
        {
            Console.WriteLine("ThrID:{0} - started: {1}", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThrID:{0} - finished: {1}", Thread.CurrentThread.ManagedThreadId, msg);
        }

        private static int Factorial(int n)
        {
            var factorial = 1;
            for (var i = 1; i <= n; i++)
                factorial *= n;
            return factorial;
        }

        private static int Sum(int n)
        {
            var sum = 1;
            for (var i = 1; i <= n; i++)
                sum += n;
            return sum;
        }
    }
}
