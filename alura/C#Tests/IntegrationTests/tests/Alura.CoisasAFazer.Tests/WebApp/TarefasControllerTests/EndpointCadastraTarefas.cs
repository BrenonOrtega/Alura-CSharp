using Moq;
using Xunit;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.WebApp.Models;
using Alura.CoisasAFazer.WebApp.Controllers;
using Alura.CoisasAFazer.Infrastructure;

namespace Alura.CoisasAFazer.Tests.WebApp.TarefasControllerTests
{
    public class EndpointCadastraTarefa
    {
        [Fact]
        public void Should_Register_NewTarefa()
        {
            //Given
            var loggerMock = new Mock<ILogger<TarefasController>>();
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("TestTarefaDb")
                .Options;

            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefas(context);

            context.Categorias.Add(new(1, "Estudo .Net com C#"));
            context.SaveChanges();

            var controller = new TarefasController(repo, loggerMock.Object);
            var viewModel = new CadastraTarefaVM()
            {
                Titulo = "Estudando Xunit e Moq",
                IdCategoria = 1,
                Prazo = new(2021, 12, 1)
            };

            //When
            var result = controller.EndpointCadastraTarefa(viewModel);

            //Then
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void ShouldReturn_NotFound_When_Category_NotFound()
        {
            //Given
            var loggerMock = new Mock<ILogger<TarefasController>>();
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("TestTarefaDb")
                .Options;

            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefas(context);

            var controller = new TarefasController(repo, loggerMock.Object);
            var viewModel = new CadastraTarefaVM()
            {
                Titulo = "Estudando Xunit e Moq",
                IdCategoria = 0,
                Prazo = new(2021, 12, 1)
            };

            //When
            var result = controller.EndpointCadastraTarefa(viewModel);

            //Then
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void ShouldReturn_BadRequest_When_CommandResult_IsNotSuccesful()
        {
            //Given
            var loggerMock = new Mock<ILogger<TarefasController>>();
            var repoMock = new Mock<IRepositorioTarefas>();

            repoMock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new System.Exception());
            repoMock.Setup(r => r.ObtemCategoriaPorId(It.IsAny<int>()))
                .Returns(new Categoria(1, "dummy"));

            var controller = new TarefasController(repoMock.Object, loggerMock.Object);

            var viewModel = new CadastraTarefaVM()
            {
                Titulo = "Estudando Xunit e Moq",
                IdCategoria = 1,
                Prazo = new(2021, 12, 1)
            };

            //When
            var result = controller.EndpointCadastraTarefa(viewModel);

            //Then
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
