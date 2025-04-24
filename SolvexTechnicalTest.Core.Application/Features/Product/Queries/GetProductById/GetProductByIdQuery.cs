using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.DTOs.Product;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ProductDTO>>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ProductDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(request.Id);
            var newRecord = _mapper.Map<ProductDTO>(record);
            return new Response<ProductDTO>(newRecord);
        }
    }
}
