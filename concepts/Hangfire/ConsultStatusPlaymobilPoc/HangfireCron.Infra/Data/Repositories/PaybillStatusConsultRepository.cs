using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using HangfireCron.Shared;
using HangfireCron.Shared.Models;

namespace HangfireCron.Infra.Data.Repositories
{
    public class PaybillStatusConsultRepository : IAsyncRepository<PaybillStatusConsult>
    {
        public async Task<PaybillStatusConsult> GetById(string id)
        {
            var bills = await GetBills();

            var bill = bills.SingleOrDefault(x => x.Id == id);

            return bill ?? PaybillStatusConsult.Empty;
        }

        public async Task SaveAsync(PaybillStatusConsult entity)
        {
            var bills = await GetBills();

            bills.Append(entity);

            await File.WriteAllTextAsync(Path.Join(AppContext.BaseDirectory, "paybills.json"), JsonSerializer.Serialize(bills));
        }

        public async Task<IEnumerable<PaybillStatusConsult>> GetBills()
        {
            var text = await File.ReadAllTextAsync(Path.Join(AppContext.BaseDirectory, "paybills.json"));
            var bills = JsonSerializer.Deserialize<List<PaybillStatusConsult>>(text,new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });

            return bills;
        }

        public Task<IEnumerable<PaybillStatusConsult>> GetAll()
        {
            return GetBills();
        }
    }
}