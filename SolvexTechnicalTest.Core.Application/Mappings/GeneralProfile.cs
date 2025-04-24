using AutoMapper;
using SolvexTechnicalTest.Core.Application.DTOs.Color;
using SolvexTechnicalTest.Core.Application.DTOs.Product;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.CreateColorCommand;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.DeleteColorCommand;
using SolvexTechnicalTest.Core.Application.Features.Color.Commands.UpdateColorCommand;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.CreateProductCommand;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.DeleteProductCommand;
using SolvexTechnicalTest.Core.Application.Features.Product.Commands.UpdateProductCommand;
using SolvexTechnicalTest.Core.Domain.Entities;

namespace SolvexTechnicalTest.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands 
            CreateMap<CreateColorCommand, Color>();
            CreateMap<UpdateColorCommand, Color>();
            CreateMap<DeleteColorCommand, Color>();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<DeleteProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            #endregion

            #region DTOS
            CreateMap<Color, ColorDTO>();
            CreateMap<Product, ProductDTO>();
            #endregion

        }
    }
}
