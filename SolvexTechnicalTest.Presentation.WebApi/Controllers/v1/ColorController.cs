using Microsoft.AspNetCore.Mvc;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.CreateColorCommand;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.DeleteColorCommand;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.UpdateColorCommand;

namespace SolvexTechnicalTest.Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ColorController : BaseApiController
    {
        #region Commmand 
        [HttpPost]
        public async Task<IActionResult> PostColor(CreateColorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteColor(int id,DeleteColorCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> PutColor(int id, UpdateColorCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
        #endregion
    }
}
