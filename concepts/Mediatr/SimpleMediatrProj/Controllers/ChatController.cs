using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleMediatrProj.Domain.Chat.Commands;
using SimpleMediatrProj.Domain.Chat.Requests;

namespace SimpleMediatrProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ILogger<ChatController> _logger;
        private readonly IMediator _mediator;
        public ChatController(IMediator mediator, ILogger<ChatController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("sending GetAllChatsRequest");
            var chats = await _mediator.Send(new GetAllChatsRequest());
            return Ok(chats);
        }

        [HttpPost]
        public async Task<IActionResult> Send(int senderId, int receiverId, string message) =>
            Accepted(new { ChatId = await _mediator.Send(new CreateChatCommand(senderId, receiverId, message)) });
    }
}
