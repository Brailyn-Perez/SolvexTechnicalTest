using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.DTOs.Color;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Color.Queries.GetColorById
{
    public class GetColorByIdQuery : IRequest<Response<ColorDTO>>{}

    public class GetColorByIdQueryHandler : IRequestHandler<GetColorByIdQuery, Response<ColorDTO>>
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public GetColorByIdQueryHandler(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Response<ColorDTO>> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
