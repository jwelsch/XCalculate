using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace XCalculate.Web.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"Program.Main caught exception: {ex}");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
