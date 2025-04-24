using Microsoft.AspNetCore.Mvc;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.CreateProductCommand;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.DeleteProductCommand;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.UpdateProductCommand;

namespace SolvexTechnicalTest.Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {

        #region Commands 
        [HttpPost]
        public async Task<IActionResult> PostProduct(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id, DeleteProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(int id, UpdateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion
    }
}
