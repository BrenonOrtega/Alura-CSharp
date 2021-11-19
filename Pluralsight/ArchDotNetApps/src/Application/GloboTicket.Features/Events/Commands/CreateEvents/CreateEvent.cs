using System;
using GloboTicket.Contracts.Commands.Events;
using MediatR;

namespace GloboTicket.Features.Events.Commands.CreateEvents
{
    public class CreateEvent : IRequest, ICreateEventCommand
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
    }
}