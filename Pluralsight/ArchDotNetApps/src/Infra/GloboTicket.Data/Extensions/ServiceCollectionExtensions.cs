using System;
using GloboTicket.Core.Repositories;
using GloboTicket.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTicketRepositories()
                .AddEventRepositories();

            return services;
        }

        static IServiceCollection AddTicketRepositories(this IServiceCollection services) => 
            services.AddTransient<ITicketAsyncRepository, TicketAsyncRepository>();
        
        static IServiceCollection AddEventRepositories(this IServiceCollection services) => 
            services.AddTransient<IEventAsyncRepository, EventAsyncRepository>();


    }
}