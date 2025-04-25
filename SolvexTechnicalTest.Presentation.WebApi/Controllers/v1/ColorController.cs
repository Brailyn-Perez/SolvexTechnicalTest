using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.CreateColorCommand;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.DeleteColorCommand;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.UpdateColorCommand;
using SolvexTechnicalTest.Core.Application.Features.Color.Queries.GetAllColor;
using SolvexTechnicalTest.Core.Application.Features.Color.Queries.GetColorById;

namespace SolvexTechnicalTest.Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ColorController : BaseApiController
    {
        #region Commmand 
        [HttpPost]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> PostColor(CreateColorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteColor(int id,DeleteColorCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> PutColor(int id, UpdateColorCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
        #endregion

        #region Queries 
        [HttpGet]
        [Authorize(Roles = "Admin,Seller,User")]
        public async Task<IActionResult> GetAllColor()
        {
            return Ok(await Mediator.Send(new GetAllColorQuery()));
        }

        [ HttpGet("{id}")]
        [Authorize(Roles = "Admin,Seller,User")]
        public async Task<IActionResult> GetColorById(int id)
        {
            var query = new GetColorByIdQuery();
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
        #endregion
    }
}
