using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace web {
    public class Relatorio : IRelatorio {
        private readonly ICatalogo catalogo;

        public Relatorio(ICatalogo catalogo){
            this.catalogo = catalogo;
        }
        public async Task Imprime(HttpContext context){
            foreach (var livro in catalogo.GetLivros()){
                await context.Response.WriteAsync($"{livro.Codigo,-10}{livro.Nome,-40}{livro.Preco.ToString("C"),10} \r\n");
            }
        }
    }
}
