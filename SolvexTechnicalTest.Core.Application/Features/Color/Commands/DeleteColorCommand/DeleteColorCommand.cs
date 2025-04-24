using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Color.Commands.DeleteColorCommand
{
    public class DeleteColorCommand : IRequest<Response<int>>
    {
        public int Id { get; set; } 
    }

    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, Response<int>>
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public DeleteColorCommandHandler(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {

            var record = await _repository.GetByIdAsync(request.Id);

            if(record == null)
            {
                throw new KeyNotFoundException("Color Not Found");
            }

            await _repository.DeleteAsync(record);
            return new Response<int>(request.Id);

        }
    }
}
