using Moq;
using Xunit;
using System;
using System.Linq;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Alura.CoisasAFazer.Tests.Services.Handlers.CadastraTarefaHandlerTests
{
    public class Execute
    {
        [Fact]
        public void Execute_Should_Return_Created_Tarefa()
        {
            //
            var loggerMock = new Mock<ILogger<CadastraTarefaHandler>>();
            var logger = loggerMock.Object;

            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("TestContextDb")
                .Options;

            var context = new DbTarefasContext(options);

            var repository = new RepositorioTarefas(context);
            var handler = new CadastraTarefaHandler(repository, logger);
            var command = new CadastraTarefa("Estudar XUnit", new Categoria("Estudo"), new System.DateTime(2021, 08, 04));

            //When
            handler.Execute(command);

            //Then
            var actual = repository
                .ObtemTarefas(x => x.Categoria == command.Categoria)
                .SingleOrDefault();

            Assert.NotNull(actual);
        }

        [Fact]
        public void Unsuccesfull_IncludeOperation_ShouldReturn_Insuccess_CommandResult()
        {
            var loggerMock = new Mock<ILogger<CadastraTarefaHandler>>(); 
            var repoMock = new Mock<IRepositorioTarefas>();

            repoMock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception());

            var repo = repoMock.Object;
            var logger = loggerMock.Object;

            var handler = new CadastraTarefaHandler(repo, logger);

            var command = new CadastraTarefa("tarefa de teste", new Categoria("categoria dummy"), new DateTime(2021, 12, 1));
            var result = handler.Execute(command);

            Assert.False(result.IsSuccesful);
        }
        

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaExcecao()
        {
            //arrange
            var mensagemDeErroEsperada = "Houve um erro na inclusão de tarefas";
            var excecaoEsperada = new Exception(mensagemDeErroEsperada);

            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>();

            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(excecaoEsperada);

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //act
            ICommandResult resultado = handler.Execute(comando);

            //assert
            mockLogger.Verify(l => 
                l.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Error), //nível de log => LogError
                    It.IsAny<EventId>(), //identificador do evento
                    It.IsAny<It.IsAnyType>(), //objeto que será logado
                    excecaoEsperada,    //exceção que será logada
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ), //função que converte objeto+exceção >> string
                Times.Once());
        }
        delegate void CapturaMensagemLog(LogLevel leve, EventId eventId, object statue, Exception ex, Func<object, Exception, string> func);
        
    }
}
