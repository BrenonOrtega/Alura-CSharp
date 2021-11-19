using GloboTicket.Features.Events.Commands.CreateEvents;
using GloboTicket.Features.Tickets.Commands.BuyTickets;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.Features.Extensions
{
    public static class Configurations
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services)
        {
            services.AddBuyTicket();
            services.AddCreateEvent();

            return services;
        }
        
        public static IServiceCollection AddBuyTicket(this IServiceCollection services) =>
            services.AddTransient<IBuyTicketHandler, BuyTicketHandler>();

        public static IServiceCollection AddCreateEvent(this IServiceCollection services) =>
            services.AddTransient<ICreateEventHandler, CreateEventHandler>();
    }
}
