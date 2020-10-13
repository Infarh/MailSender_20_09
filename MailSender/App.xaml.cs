using System;
using MailSender.lib.Interfaces;
using MailSender.lib.Service;
using MailSender.ViewModels;
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

            //services.AddScoped<>()

            //using (var scope = Services.CreateScope())
            //{
            //    var mail_service = scope.ServiceProvider.GetRequiredService<IMailService>();
            //    var sender = mail_service.GetSender("smtp.mail.ru", 25, true, "Login", "Password");
            //    sender.Send("sender@mail.ru", "recipient@gmail.com", "Title", "Body");
            //}
        }
    }
}
