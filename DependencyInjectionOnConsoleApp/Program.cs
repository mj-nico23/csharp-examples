using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionOnConsoleApp
{
    public class Program
    {
        private readonly ILogger<Program> logger;
        private readonly MyServiceA myServiceA;


        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        public Program(ILogger<Program> logger, MyServiceA myServiceA)
        {
            this.logger = logger;
            this.myServiceA = myServiceA;
        }

        public void Run()
        {
            logger.LogInformation("Program is running.");
            myServiceA.DoSomething();
            logger.LogInformation("Program is completed.");
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<MyServiceA>();
                    services.AddTransient<MyServiceB>();
                });
        }
    }

    public class MyServiceA
    {
        private readonly MyServiceB myServiceB;

        public MyServiceA(MyServiceB myServiceB)
        {
            this.myServiceB = myServiceB;
        }

        public void DoSomething() => myServiceB.DoSomething();
    }

    public class MyServiceB
    {
        private readonly ILogger<MyServiceB> logger;

        public MyServiceB(ILogger<MyServiceB> logger)
        {
            this.logger = logger;
        }

        public void DoSomething() => logger.LogInformation("My Service B is doing something.");
    }
}
