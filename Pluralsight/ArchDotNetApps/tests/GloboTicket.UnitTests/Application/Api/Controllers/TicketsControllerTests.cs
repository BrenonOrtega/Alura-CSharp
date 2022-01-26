using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Api.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using MediatR;
using Xunit;
using GloboTicket.Api.Models.Requests;

namespace GloboTicket.UnitTests.Application.Api.Controllers
{
    public class TicketsControllerTests
    {
        [Fact]
        public void Buy_TicketAction_Should_Return_OkResult()
        {
        //Given
            var loggerMock = new Mock<ILogger<TicketsController>>();
            var mediatorMock = new Mock<IMediator>();
            var mapperMock = new Mock<IMapper>();

            var controller = new TicketsController(loggerMock.Object, mediatorMock.Object, mapperMock.Object);
            var request = new BuyTicketRequest()
            {
                
            };
        //When

        //Then
        }
    }
}