using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.DTOs.Product;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Product.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<Response<List<ProductDTO>>>{}

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, Response<List<ProductDTO>>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<ProductDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var listrecord = await _repository.GetAllAsync();
            var newListRecord = _mapper.Map<List<ProductDTO>>(listrecord);
            return new Response<List<ProductDTO>>(newListRecord);
        }
    }
}
