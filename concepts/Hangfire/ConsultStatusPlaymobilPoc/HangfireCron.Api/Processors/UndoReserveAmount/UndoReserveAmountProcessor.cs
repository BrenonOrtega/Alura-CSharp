using HangfireCron.Shared.Models;

namespace HangfireCron.Api.Processors.UndoReserveAmount
{
    class UndoReserveAmountProcessor : IUndoReserveAmountProcessor
    {
        private readonly ILogger<UndoReserveAmountProcessor> _logger;

        public UndoReserveAmountProcessor(ILogger<UndoReserveAmountProcessor> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task ProcessAsync(PaybillStatusConsult billStatus)
        {
            _logger.LogInformation("Undoing Amount Reserve for Paybill: {id}", billStatus?.Id);
            return Task.CompletedTask;
        }
    }
}