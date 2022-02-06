using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Outbox.Pattern.Application.Billings.Services;
using Outbox.Pattern.Domain;

namespace Outbox.Pattern.Api.Controllers
{
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillsController(IBillingService billingService) =>
            _billingService = billingService ?? throw new ArgumentNullException(nameof(billingService));

        [HttpGet("{billId}")]
        public async Task<IActionResult> GetBillAsync(Guid billId)
        {
            var bill = await _billingService.GetBillAsync(billId);

            return bill is default(Billing) || bill.Equals(Billing.Empty)
                ? NotFound()
                : Ok(bill);
        }
    }
}
