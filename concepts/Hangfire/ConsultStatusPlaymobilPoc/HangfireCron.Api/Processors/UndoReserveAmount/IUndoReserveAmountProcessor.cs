using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangfireCron.Shared.Models;

namespace HangfireCron.Api.Processors.UndoReserveAmount
{
    public interface IUndoReserveAmountProcessor
    {
        Task ProcessAsync(PaybillStatusConsult billStatus);
    }
}