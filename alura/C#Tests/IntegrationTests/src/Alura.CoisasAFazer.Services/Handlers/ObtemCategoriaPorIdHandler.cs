using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Alura.CoisasAFazer.Services.Handlers
{
    public class ObtemCategoriaPorIdHandler 
    {
        IRepositorioTarefas _repo;
        private ILogger _logger;

        public ObtemCategoriaPorIdHandler(IRepositorioTarefas repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public Categoria Execute(ObtemCategoriaPorId comando)
        {
            return _repo.ObtemCategoriaPorId(comando.IdCategoria);
        }
    }
}
