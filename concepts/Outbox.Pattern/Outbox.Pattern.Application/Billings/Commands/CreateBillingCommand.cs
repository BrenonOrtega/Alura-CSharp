using System;
using Outbox.Pattern.Domain;

namespace Outbox.Pattern.Application.Billings.Commands
{
    public class CreateBillingCommand
    {
        public Billing Billing { get; set; } = Billing.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ProcessedAt { get; set; } = null;
    }
}