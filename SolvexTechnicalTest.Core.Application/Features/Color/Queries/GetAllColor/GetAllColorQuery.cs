using AutoMapper;
using MediatR;
using SolvexTechnicalTest.Core.Application.DTOs.Color;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Features.Color.Queries.GetAllColor
{
    public class GetAllColorQuery : IRequest<Response<List<ColorDTO>>>{}

    public class GetAllColorQueryHandler : IRequestHandler<GetAllColorQuery, Response<List<ColorDTO>>>
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public GetAllColorQueryHandler(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Response<List<ColorDTO>>> Handle(GetAllColorQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
