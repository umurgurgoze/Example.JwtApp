using ExampleJwtApp.Back.Core.Application.Features.CQRS.Commands;
using ExampleJwtApp.Back.Core.Application.Features.CQRS.Queries;
using ExampleJwtApp.Back.Infrastracture.Tools;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ExampleJwtApp.Back.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /* 1 - UserRegister => Member Rolü ile birlikte register ederiz.
  2 - UserName, password eşleşiyorsa token üretilecek.
  3 - Password change edilebilir. User içindeki bir takım bilgileri update edebiliriz.
*/
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {
            var userDto = await _mediator.Send(request);
            if (userDto.IsExist)
            {
                var token = JwtTokenGenerator.GenerateToken(userDto);
                return Created("", token);
            }
            return BadRequest("Username veya password hatalı");
        }
    }
}
