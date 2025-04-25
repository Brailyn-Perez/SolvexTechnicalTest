using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolvexTechnicalTest.Core.Application.Features.User.Queries.GetAllUsers;
using SolvexTechnicalTest.Core.Application.Features.User.Queries.GetUsersById;

namespace SolvexTechnicalTest.Presentation.WebApi.Controllers.v1
{
    public class UserController : BaseApiController
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllUsers()));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetUserById();
            query.Id = id;
            return Ok(await Mediator.Send(query));
        }
    }
}
