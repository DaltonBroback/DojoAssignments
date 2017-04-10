using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace YourNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                // Use Startup.cs to configure server
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}