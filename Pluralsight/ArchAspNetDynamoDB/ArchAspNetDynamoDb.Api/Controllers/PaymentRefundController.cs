using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchAspNetDynamoDb.Domain.Models.Entities;
using ArchAspNetDynamoDb.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArchAspNetDynamoDb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentRefundController : ControllerBase
    {
        private readonly ILogger<PaymentRefundController> _logger;
        private readonly IPaymentRefundService _service;

        public PaymentRefundController(ILogger<PaymentRefundController> logger, IPaymentRefundService service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IEnumerable<PaymentRefund> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new PaymentRefund()
            {
               
            }).ToArray();
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _service.GetAllPayments();

            return payments.Any() ? Ok(payments) : NoContent(); 
        }

    }
}
