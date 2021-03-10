using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace example {
    public interface IRelatorio{
        Task Imprime(HttpContext context);
    }
}
