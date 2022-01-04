using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangfireCron.Shared.Models;

namespace HangfireCron.Api.Services.Paybill
{
    public interface IPaybillService
    {
        Task<PaybillStatusConsult> GetPaybill(string id);
        Task<IEnumerable<PaybillStatusConsult>> GetAll();
    }
}