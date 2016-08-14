using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AutofacMultitenancy1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseWebListener()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls(new[]
                {
                    "http://tenant1.local",
                    "http://tenant2.local"
                })
                .Build();

            host.Run();
        }
    }
}
