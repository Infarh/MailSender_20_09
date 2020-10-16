using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTests.Data;
using ConsoleTests.Data.Entityes;
using MailSender.lib.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var report = new StatisticReport();

            report.SendedMailsCount = 1000;

            report.CreatePackage("statistic.docx");


            //Console.ReadLine();
        }
    }
}
