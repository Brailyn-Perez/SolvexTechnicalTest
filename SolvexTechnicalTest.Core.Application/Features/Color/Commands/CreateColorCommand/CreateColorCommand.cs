using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Color.Commands.CreateColorCommand
{
    public class CreateColorCommand : IRequest<Response<int>>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public decimal Price { get; set; }

    }

    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, Response<int>>
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public CreateColorCommandHandler(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Domain.Entities.Color>(request);
            return new Response<int>(await _repository.CreateAsync(newRecord));
        }
    }
}
