using System;

namespace Outbox.Pattern.Domain.Commands
{
    public class CreateBillingCommand
    {
        public Billing Billing { get; set; } = Billing.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ProcessedAt { get; set; } = null;
    }
}