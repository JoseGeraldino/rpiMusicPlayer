using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MusicPlayer
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();
            host.Run();
        }

        /// <summary>
        /// Creates new web hosting service.
        /// </summary>
        /// <param name="args"> command line arguments</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseDefaultServiceProvider(options =>
                    {
                        options.ValidateOnBuild = true;
                        options.ValidateScopes = false;

                    })
                    .UseKestrel((options) =>
                    {
                        options.ListenAnyIP(8080);
                    })
                    ;
                });
        }


    }
}
