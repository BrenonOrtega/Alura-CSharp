using Moq;
using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Core.Models;

namespace Alura.CoisasAFazer.Tests.Services.Handlers.GerenciaPrazoDasTarefasHandlerTests
{
    public class Execute
    {
        [Fact]
        public void TasksBefore_MarchFirst_ShouldBe_Late()
        {
            //Given
            var compras = new Categoria(1, "compras");
            var casa = new Categoria(2, "casa");
            var trabalho = new Categoria(3, "trabalho");
            var saude = new Categoria(4, "saude");
            var estudo = new Categoria(5, "estudo");

            var tarefasAtrasadas = new List<Tarefa>
            {
                new Tarefa(1, "Comprar pão", compras, new DateTime(2021, 02, 28), null, StatusTarefa.Criada),
                new Tarefa(4, "Limpar o corredor", casa, new DateTime(2021, 02, 25), null, StatusTarefa.Criada),
                new Tarefa(6, "Ir ao dentista", saude, new DateTime(2021, 01, 31), null, StatusTarefa.Criada),
                new Tarefa(9, "Entregar testes unitários", trabalho, new DateTime(2021, 02, 20), null, StatusTarefa.Criada),
            };

            var tarefasEmAberto = new List<Tarefa>
            {
                new Tarefa(2, "Limpar o quintal", casa, new DateTime(2021, 03, 21), null, StatusTarefa.Criada),
                new Tarefa(3, "entrega do software", trabalho, new DateTime(2021, 03, 2), null, StatusTarefa.Criada),
                new Tarefa(5, "finalizar curso de testes", estudo, new DateTime(2021, 03, 1), null, StatusTarefa.Criada),
                new Tarefa(7, "comprar presente de aniversario", compras, new DateTime(2021, 03, 20), null, StatusTarefa.Criada),
                new Tarefa(8, "parar de comer doce", saude, new DateTime(2021, 03, 02), null, StatusTarefa.Criada),
            };

            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;

            var context = new DbTarefasContext(options);
            var repository = new RepositorioTarefas(context);

            var command = new GerenciaPrazoDasTarefas(new DateTime(2021, 03, 01));
            var handler = new GerenciaPrazoDasTarefasHandler(repository);

            repository.IncluirTarefas(tarefasAtrasadas.ToArray());
            repository.IncluirTarefas(tarefasEmAberto.ToArray());

            //When
            handler.Execute(command);

            //Then
            var expected = 5;
            var actual = repository.ObtemTarefas(tarefa => tarefa.Status.Equals(StatusTarefa.EmAtraso)).Count();
            Assert.True(expected == actual);
        }

        [Fact]
        public void Including_ListOfTarefas_ShouldBeCalled_ExpectedNumberOfTimes()
        {
            //Given
            var dummyCategory = new Categoria(1, "dummy");
            var tarefasEmAberto = new List<Tarefa>
            {
                new Tarefa(2, "Limpar o quintal", dummyCategory, new DateTime(2021, 03, 21), null, StatusTarefa.Criada),
                new Tarefa(3, "entrega do software", dummyCategory, new DateTime(2021, 03, 2), null, StatusTarefa.Criada),
                new Tarefa(5, "finalizar curso de testes", dummyCategory, new DateTime(2021, 03, 1), null, StatusTarefa.Criada),
                new Tarefa(7, "comprar presente de aniversario", dummyCategory, new DateTime(2021, 03, 20), null, StatusTarefa.Criada),
                new Tarefa(8, "parar de comer doce", dummyCategory, new DateTime(2021, 03, 02), null, StatusTarefa.Criada),
            };

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.ObtemTarefas(It.IsAny<Func<Tarefa, bool>>()))
                .Returns(tarefasEmAberto);

            var repo = mock.Object; 
            var command = new GerenciaPrazoDasTarefas(new DateTime(2021, 08, 06));
            var handler = new GerenciaPrazoDasTarefasHandler(repo);

            //When
            handler.Execute(command);

            //Then
            mock.Verify(r => r.AtualizarTarefas(It.IsAny<Tarefa[]>()), Times.Once());
        }

        public static IRepositorioTarefas GetInMemoryRepo()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;

            var context = new DbTarefasContext(options);
            var repository = new RepositorioTarefas(context);

            return repository;
        }
    }
}
