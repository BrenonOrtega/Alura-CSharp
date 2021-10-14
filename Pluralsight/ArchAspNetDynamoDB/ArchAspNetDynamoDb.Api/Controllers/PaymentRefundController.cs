using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchAspNetDynamoDb.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArchAspNetDynamoDb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentRefundController : ControllerBase
    {
        private readonly ILogger<PaymentRefundController> _logger;

        public PaymentRefundController(ILogger<PaymentRefundController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PaymentRefund> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new PaymentRefund()
            {
               
            }).ToArray();
        }
    }
}
