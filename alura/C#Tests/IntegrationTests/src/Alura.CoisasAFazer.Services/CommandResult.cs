using Alura.CoisasAFazer.Core.Commands;

namespace Alura.CoisasAFazer.Services
{
    public class CommandResult : ICommandResult
    {
        public bool IsSuccesful { get; }

        public CommandResult(bool succesful)
        {
            IsSuccesful = succesful;
        }
    }
}