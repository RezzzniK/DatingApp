using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        /*we going to change void type of main to async Task*/
        public static async Task Main(string[] args)
        {
            /*changing hostbuilder 
            before change:
            CreateHostBuilder(args).Build().Run();
            after change:
            */
            var host=CreateHostBuilder(args).Build();
            using var scope =host.Services.CreateScope();
            var services=scope.ServiceProvider;
            //creating try catch for injecting service
            try
            {
                 var context= services.GetRequiredService<DataContext>();
                 //now we will get tha Database and migrate it here
                 await context.Database.MigrateAsync();//it will create db if its not already exists
                 await Seed.SeedUsers(context);//passing data from SeedUsers method to context

            }
            catch (Exception ex)
            {
                //creating a logger var and passing him program.cs as type
                var logger=services.GetRequiredService<ILogger<Program>>();
                //creating logger to show the error during migration
                logger.LogError(ex,"An error occurred during migration");
                
            }
            /*because we removed run command from beginning we need to remove back inside
            to apply our settings*/
           await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
