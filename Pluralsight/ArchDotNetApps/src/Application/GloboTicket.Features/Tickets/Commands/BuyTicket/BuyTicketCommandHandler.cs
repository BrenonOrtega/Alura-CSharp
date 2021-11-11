using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Contracts.Commands;
using GloboTicket.Core.Models;
using GloboTicket.Core.Repositories;
using GloboTicket.Features.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GloboTicket.Features.Tickets.Commands.BuyTicket
{
    public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand>, IBuyTicketCommandHandler
    {
        private readonly IMapper mapper;
        private readonly ILogger<BuyTicketCommandHandler> logger;
        private readonly ITicketAsyncRepository repo;

        public BuyTicketCommandHandler(IMapper mapper, ILogger<BuyTicketCommandHandler> logger, ITicketAsyncRepository repo)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public async Task<Unit> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            await HandleAsync(request, cancellationToken);
            return Unit.Value;
        }

        public async Task HandleAsync(IBuyTicketCommand command, CancellationToken token = default)
        {
            var ticket = mapper.Map<Ticket>(command);
            logger.LogInformation("Creating Ticket {ticketData}.", JsonSerializer.Serialize(ticket));

            await repo.SaveAsync(ticket);
        }
    }
}