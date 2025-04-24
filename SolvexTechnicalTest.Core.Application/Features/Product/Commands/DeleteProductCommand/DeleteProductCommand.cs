using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<int>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(record);

            return new Response<int>(request.Id);
        }
    }
}
