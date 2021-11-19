using System.Threading;
using System.Threading.Tasks;
using GloboTicket.Contracts.Commands.Events;

namespace GloboTicket.Features.Events.Commands.CreateEvents
{
    public interface ICreateEventHandler
    {
        Task HandleAsync(ICreateEventCommand command, CancellationToken token);
    }
}