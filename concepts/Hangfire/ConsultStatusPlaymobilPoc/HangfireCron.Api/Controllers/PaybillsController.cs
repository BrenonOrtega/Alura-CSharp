using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HangfireCron.Api.Services.Paybill;
using HangfireCron.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HangfireCron.Api.Controllers
{
    [Route("[controller]")]
    public class PaybillsController : ControllerBase
    {
        private readonly ILogger<PaybillsController> _logger;
        private readonly IPaybillService _service;

        public PaybillsController(ILogger<PaybillsController> logger, IPaybillService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var bill = await _service.GetPaybill(id);

            return bill.Equals(PaybillStatusConsult.Empty) 
                ? Ok(bill) 
                : NotFound(bill);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAll());

    }
}