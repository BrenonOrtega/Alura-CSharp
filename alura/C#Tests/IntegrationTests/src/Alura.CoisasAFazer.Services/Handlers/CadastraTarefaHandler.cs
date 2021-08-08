using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.Extensions.Logging;
using System;

namespace Alura.CoisasAFazer.Services.Handlers
{
    public class CadastraTarefaHandler : IHandler
    {
        IRepositorioTarefas _repo;
        ILogger _logger;


        public CadastraTarefaHandler(IRepositorioTarefas repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public ICommandResult Execute(CadastraTarefa comando)
        {
            try
            {
                var tarefa = new Tarefa
               (
                   id: 0,
                   titulo: comando.Titulo,
                   prazo: comando.Prazo,
                   categoria: comando.Categoria,
                   concluidaEm: null,
                   status: StatusTarefa.Criada
               );

                _logger.LogDebug("Persistindo a tarefa...");
                _repo.IncluirTarefas(tarefa);

                return new CommandResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new CommandResult(false);
            }
        }
    }
}
