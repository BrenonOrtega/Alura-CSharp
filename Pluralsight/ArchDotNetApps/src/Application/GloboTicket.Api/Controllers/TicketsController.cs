using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GloboTicket.Api.Models.Tickets.Responses;
using GloboTicket.Features.Tickets.Commands.BuyTickets;
using GloboTicket.Messaging.Commands;

namespace GloboTicket.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> logger;
        private readonly IBuyTicketHandler handler;
        private readonly IMapper mapper;

        public TicketsController(ILogger<TicketsController> logger, IBuyTicketHandler handler, IMapper mapper)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("{quantity}")]
        public async Task<ActionResult<BuyTicketResponse>> GetBoughtTicketAsync(int quantity)
        {

            var command = new BuyTicketCommand()
            {
                Amount = quantity,
                BuyerId
            };

            var await handler.HandleAsync()
        }


    }
}