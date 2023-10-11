using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .Build();

        host.Run();
    }
}