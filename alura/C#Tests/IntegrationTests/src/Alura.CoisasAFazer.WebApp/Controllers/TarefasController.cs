using Microsoft.AspNetCore.Mvc;
using Alura.CoisasAFazer.WebApp.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.Extensions.Logging;
using System;

namespace Alura.CoisasAFazer.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IRepositorioTarefas _repo;

        private readonly ILogger _logger;

        public TarefasController(IRepositorioTarefas repo, ILogger<TarefasController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EndpointCadastraTarefa(CadastraTarefaVM model)
        {
            var cmdObtemCateg = new ObtemCategoriaPorId(model.IdCategoria);
            var categoria = new ObtemCategoriaPorIdHandler(_repo, _logger).Execute(cmdObtemCateg);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            var comando = new CadastraTarefa(model.Titulo, categoria, model.Prazo);

            var handler = new CadastraTarefaHandler(_repo, _logger);
            var commandResult = handler.Execute(comando);

            Func<object, IActionResult> result = commandResult.IsSuccesful ? Ok : BadRequest;
            
            return result(commandResult);
        }
    }
}