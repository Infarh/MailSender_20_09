using System;
using System.Windows;
using MailSender.Data;
using MailSender.Data.Stores.InDB;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using MailSender.lib.Service;
using MailSender.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MailSender
{
    public partial class App
    {
        private static IHost _Hosting;

        public static IHost Hosting => _Hosting
            ??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
               .ConfigureHostConfiguration(cfg => cfg
                   .AddJsonFile("appconfig.json", true, true)
                   .AddXmlFile("appsettings.xml", true, true)
                )
               .ConfigureAppConfiguration(cfg => cfg
                   .AddJsonFile("appconfig.json", true, true)
                   .AddXmlFile("appsettings.xml", true, true)
                )
               .ConfigureLogging(log => log
                   .AddConsole()
                   .AddDebug()
                )
               .ConfigureServices(ConfigureServices)
               .Build();

        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif

            services.AddSingleton<IEncryptorService, Rfc2898Encryptor>();

            services.AddDbContext<MailSenderDB>(opt => opt
               .UseSqlServer(host.Configuration.GetConnectionString("Default")));
            services.AddTransient<MailSenderDbInitializer>();

            //services.AddSingleton<IStore<Recipient>, RecipientsStoreInMemory>();

            services.AddSingleton<IStore<Recipient>, RecipientsStoreInDB>();
            services.AddSingleton<IStore<Sender>, SendersStoreInDB>();
            services.AddSingleton<IStore<Server>, ServersStoreInDB>();
            services.AddSingleton<IStore<Message>, MessagesStoreInDB>();
            services.AddSingleton<IStore<SchedulerTask>, SchedulerTasksStoreInDB>();

            services.AddSingleton<IMailSchedulerService, TaskMailSchedulerService>();
            //...
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Services.GetRequiredService<MailSenderDbInitializer>().Initialize();
            base.OnStartup(e);

            //using (var db = Services.GetRequiredService<MailSenderDB>())
            //{
            //    var to_remove = db.SchedulerTasks.Where(task => task.Time < DateTime.Now);
            //    if(to_remove.Any())
            //    {
            //        db.SchedulerTasks.RemoveRange(to_remove);
            //        db.SaveChanges();
            //    }
            //}
        }
    }
}
