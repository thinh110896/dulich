using DotNetCore.CAP;
using Tourism.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Tourism.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("send-message")]
        public Task SendMessage([FromServices] ICapPublisher capPublisher)
        {
            return capPublisher.PublishAsync("foo.one", new { hello = "ok" });
        }

    }
}
