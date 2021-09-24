using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using SimpleMediatrProj.Controllers;
using Xunit;

namespace SimpleMediatrProj.Tests.Controllers
{
    public class ChatControllerTests
    {
        [Fact]
        public void TestName()
        {
        //Given
            var loggerMock = new Mock<ILogger<ChatController>>();
            var logger = loggerMock.Object;
            var mediatrMock = new Mock<IMediator>();
            var mediator = mediatrMock.Object;
            var controller = new ChatController(mediator, logger);
        //When
            controller.Send(1,2, "hello mate");
        //Then
        }
        
    }
}