using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Color.Commands.UpdateColorCommand
{
    public class UpdateColorCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, Response<int>>
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public UpdateColorCommandHandler(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(request.Id);

            if (record == null)
            {
                throw new KeyNotFoundException("Color not found");
            }

            record.Name = request.Name;
            record.Price = request.Price;
            record.HexCode = request.HexCode;

            await _repository.UpdateAsync(record);
            return new Response<int>(request.Id);
        }
    }
}
