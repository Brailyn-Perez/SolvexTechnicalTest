using SolvexTechnicalTest.Core.Application.Interfaces.Services.ReadsServices;
using SolvexTechnicalTest.Core.Domain.Repositories;

namespace SolvexTechnicalTest.Core.Application.Services
{
    public class ColorReadService : IColorReadService
    {
        private readonly IColorRepository _repository;

        public ColorReadService(IColorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExistsAsync(int id,CancellationToken ct)
        {
            return await _repository.ExistsAsync(id);
        }
    }
}
