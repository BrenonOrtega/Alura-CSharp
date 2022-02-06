using System;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Outbox.Pattern.Api
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            builder.ConfigureServices(services => 
            {
                services.AddControllers();
                services.AddAuthentication();
                services.AddAuthorization();
            });

            var app = builder.Build();

            app.Start();
        }
    }
}