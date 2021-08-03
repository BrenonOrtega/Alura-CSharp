using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace SecureClient
{
    class Program
    {
        public static IConfiguration Configuration;
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).ConfigureServices(services => {
                services.Configure<AuthConfig>(options => Configuration.GetSection("AuthConfig").Bind(options));
                services.AddSingleton<Authenticator>();
            }).Build();


            var config = host.Services.GetRequiredService<IOptions<AuthConfig>>().Value;
            System.Console.WriteLine($"Authority: { config.Authority }");

            IConfidentialClientApplication app;

            app = ConfidentialClientApplicationBuilder
                    .Create(config.ClientId)
                    .WithClientSecret(config.ClientSecret)
                    .WithAuthority(new Uri(config.Authority))
                    .Build();
            
            var authenticator = host.Services.GetRequiredService<Authenticator>();
            var resourceIds = new string[] { config.ResourceId };

            var token = await authenticator.GetAuthenticationTokenAsync(app, resourceIds);

            await authenticator.SendAuthenticatedRequest(config.BaseAddress, token);

            await Task.CompletedTask;         
        }

        static IHostBuilder CreateHostBuilder(string[] args) => 
            Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, configurationBuilder) => {
                IHostEnvironment env = hostingContext.HostingEnvironment;

                configurationBuilder
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("AppSettings.Json", optional: true, reloadOnChange:true)
                    .AddJsonFile("AppSettings.Development.Json", true, true)
                    ;

                Configuration = configurationBuilder.Build();
            });
    }
}
