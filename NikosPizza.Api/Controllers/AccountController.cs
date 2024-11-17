using MediatR;
using Microsoft.AspNetCore.Mvc;
using NikosPizza.Application.Queries.register;
using NikosPizza.Application.Queries.Register;

namespace NikosPizza.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = new UserRegisterQuery
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _mediator.Send(query);

            if (result.IsSuccess)
            {
                return Ok(new { message = result.Mensaje });
            }

            return BadRequest(new { message = result.Mensaje });
        }
    }

    // DTO para las solicitudes HTTP
    public class UserRegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

