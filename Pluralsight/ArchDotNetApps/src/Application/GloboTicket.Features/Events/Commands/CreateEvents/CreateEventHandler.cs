using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Contracts.Commands.Events;
using GloboTicket.Core.Models;
using GloboTicket.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GloboTicket.Features.Events.Commands.CreateEvents
{
    public class CreateEventHandler : ICreateEventHandler, IRequestHandler<CreateEvent, Unit>
    {
        private readonly ILogger<CreateEventHandler> logger;
        private readonly IEventAsyncRepository repo;
        private readonly IMapper mapper;

        public CreateEventHandler(ILogger<CreateEventHandler> logger, IEventAsyncRepository repo, IMapper mapper)
        {
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            this.repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }
        public async Task<Unit> Handle(CreateEvent request, CancellationToken cancellationToken)
        {
            await HandleAsync(request, cancellationToken);

            return Unit.Value;
        }

        public Task HandleAsync(ICreateEventCommand command, CancellationToken token)
        {
            var @event = mapper.Map<Event>(command);

            return repo.SaveAsync(@event);
        }
    }
}