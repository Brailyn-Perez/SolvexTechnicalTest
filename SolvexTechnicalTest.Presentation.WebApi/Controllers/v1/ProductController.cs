using Microsoft.AspNetCore.Mvc;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.CreateProductCommand;

namespace SolvexTechnicalTest.Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {

        #region Commands 
        [HttpPost]
        public async Task<IActionResult> PostProduct(CreateProductCommand command)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
