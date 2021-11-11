using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Features.Tickets.Commands.BuyTicket;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.Features.Extensions
{
    public static class Configurations
    {
        public static IServiceCollection AddBuyTicket(this IServiceCollection services) =>
            services.AddTransient<IBuyTicketCommandHandler, BuyTicketCommandHandler>();
    }
}
