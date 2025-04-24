using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? ColorId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Domain.Entities.Product>(request);
            return new Response<int>(await _repository.CreateAsync(newRecord));
        }
    }
}
