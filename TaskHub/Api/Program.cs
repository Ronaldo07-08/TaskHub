using Api.Hw.DI_task;
using LoggingLibrary;

namespace Api;

/// <summary>
/// Точка входа приложения
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Запуск приложения
    /// </summary>
    public static void Main(string[] args)
    {

        var host = Host.CreateDefaultBuilder(args)
            .UseInfraSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();

        using (var scope = host.Services.CreateScope())
        {
            Console.WriteLine("[SCOPE] ---------------FIRST SCOPE---------------");
            var provider = scope.ServiceProvider;

            provider.TestResolve<ITransient1>();
            provider.TestResolve<ITransient2>();
            provider.TestResolve<IScoped1>();
            provider.TestResolve<IScoped2>();
            provider.TestResolve<ISingleton1>();
            provider.TestResolve<ISingleton2>();

            Console.WriteLine();
        }

        using (var scope = host.Services.CreateScope())
        {
            Console.WriteLine();
            Console.WriteLine("[SCOPE] ---------------SECOND SCOPE---------------");
            var provider = scope.ServiceProvider;

            provider.TestResolve<ITransient1>();
            provider.TestResolve<ITransient2>();
            provider.TestResolve<IScoped1>();
            provider.TestResolve<IScoped2>();
            provider.TestResolve<ISingleton1>();
            provider.TestResolve<ISingleton2>();

            Console.WriteLine();
        }

        host.Run();
    }
}