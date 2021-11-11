using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MediatR;
using AutoMapper;

namespace GloboTicket.Api.Controllers
{
    public class TicketsController
    {
        private readonly ILogger<TicketsController> logger;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public TicketsController(ILogger<TicketsController> logger, IMediator mediator, IMapper mapper)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}