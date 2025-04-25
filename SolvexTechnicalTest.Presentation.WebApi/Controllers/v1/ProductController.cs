using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.CreateProductCommand;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.DeleteProductCommand;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.UpdateProductCommand;
using SolvexTechnicalTest.Core.Application.Features.Product.Queries.GetAllProduct;
using SolvexTechnicalTest.Core.Application.Features.Product.Queries.GetProductById;

namespace SolvexTechnicalTest.Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {

        #region Commands 
        [HttpPost]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> PostProduct(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id, DeleteProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion

        #region Queries 
        [HttpGet]
        [Authorize(Roles = "Admin,Seller,User")]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await Mediator.Send(new GetAllProductQuery()));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Seller,User")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetProductByIdQuery();
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
        #endregion
    }
}
