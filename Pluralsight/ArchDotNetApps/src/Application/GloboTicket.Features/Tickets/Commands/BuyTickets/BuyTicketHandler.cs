using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Contracts.Commands.Tickets;
using GloboTicket.Core.Models;
using GloboTicket.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GloboTicket.Features.Tickets.Commands.BuyTickets
{
    internal class BuyTicketHandler : IRequestHandler<BuyTicket>, IBuyTicketHandler
    {
        private readonly IMapper mapper;
        private readonly ILogger<BuyTicketHandler> logger;
        private readonly ITicketAsyncRepository repo;

        public BuyTicketHandler(IMapper mapper, ILogger<BuyTicketHandler> logger, ITicketAsyncRepository repo)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public async Task<Unit> Handle(BuyTicket request, CancellationToken cancellationToken)
        {
            await HandleAsync(request, cancellationToken);
            return Unit.Value;
        }

        public Task HandleAsync(IBuyTicketCommand command, CancellationToken token = default)
        {
            var ticket = mapper.Map<Ticket>(command);
            logger.LogInformation("Creating Ticket {ticketData}.", JsonSerializer.Serialize(ticket));

            return repo.SaveAsync(ticket);
        }
    }
}