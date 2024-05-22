using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ASPWebExamBelsky.Controllers.ApiMessages;

namespace ASPWebExamBelsky.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public StringMessage Index() => new StringMessage(Message: "server is running");

        [HttpGet("ping")]
        public StringMessage Ping() => new StringMessage(Message: "pong");
    }
}
