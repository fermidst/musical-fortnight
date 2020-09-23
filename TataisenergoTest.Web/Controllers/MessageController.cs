using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TataisenergoTest.Web.Dtos;
using TataisenergoTest.Web.Services;

namespace TataisenergoTest.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("encrypt")]
        public async Task<EncryptResponseDto> Encrypt(EncryptRequestDto requestDto)
        {
            var encryptedMessage = await _messageService.EncryptMessage(requestDto.Message);
            return new EncryptResponseDto
            {
                EncryptedMessage = encryptedMessage
            };
        }
    }
}