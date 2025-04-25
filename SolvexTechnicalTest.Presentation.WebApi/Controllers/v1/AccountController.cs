using Microsoft.AspNetCore.Mvc;
using SolvexTechnicalTest.Core.Application.DTOs.Users;
using SolvexTechnicalTest.Core.Application.Features.Authenticate.Command.AuthenticateCommand;
using SolvexTechnicalTest.Core.Application.Features.Authenticate.Command.RegisterCommand;

namespace SolvexTechnicalTest.Presentation.WebApi.Controllers.v1
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await Mediator.Send(new AuthenticateCommand()
            {
                Email = request.Email,
                Password = request.Password,
                IpAddress = GenerateIpAddress()

            }));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterCommand()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirmed = request.PasswordConfirmed,
                Origin = Request.Headers["origin"]
            }));
        }

        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
