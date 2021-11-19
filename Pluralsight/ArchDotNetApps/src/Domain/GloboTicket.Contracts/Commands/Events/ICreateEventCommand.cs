using System;

namespace GloboTicket.Contracts.Commands.Events
{
    public interface ICreateEventCommand
    {
        string Name { get; set; }
        string Creator { get; set; }
        DateTime Date { get; set; }
    }
}