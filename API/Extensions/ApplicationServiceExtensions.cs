using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicactionServices(this IServiceCollection services,IConfiguration config)
        {
             services.AddScoped<ITokenService,TokenService>();//service will be exist as long as http request
             /*we want to add our IUserRepository interface and UserRepository 
             implementations to our services*/
             services.AddScoped<IUserRepository,UserRepository>();

            /*adding automapper services*/
             services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

             services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));//UseSqlServer("connection stirng");
            });
            return services;
        }
    }
}