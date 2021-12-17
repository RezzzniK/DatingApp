using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddlware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddlware(RequestDelegate next/*whats comming nex in pipline*/,
        ILogger <ExceptionMiddlware> logger/*displaying our exception in terminal window*/,
        IHostEnvironment env/*checkin in wich environment we are(Productin,Developing,Testing*/)
        {//initializing field from parameters in constructor
            _next=next;
            _logger=logger;
            _env=env;

        }
        public async Task InvokeAsync(HttpContext context)//here we gonna use all try catch blocks 
                                                         //and catching all the exceptions
        {
            try{
                await _next(context);//getting context to the middleware
                //jummping to the top of middlware
            }
            catch(Exception ex)//when we catching exceptions
            {
                _logger.LogError(ex,ex.Message);//first we want to show it in the terminal
                /*now we want to write our exception to the response*/
                context.Response.ContentType="application/json";
                context.Response.StatusCode=(int) HttpStatusCode.InternalServerError;
                var response=_env.IsDevelopment()
                ? new ApiException(context.Response.StatusCode,ex.Message,ex.StackTrace?.ToString())
                :new ApiException(context.Response.StatusCode,"Internal sever error");
                //we want to return all this in JSON with camel case
                //to make CamelCase option be enabled, we making options var
                var options=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
                //now we want to pass all this options to jsonserializer
                var json=JsonSerializer.Serialize(response,options);
                await context.Response.WriteAsync(json);
            }

        }
    }
}