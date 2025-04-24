using SolvexTechnicalTest.Core.Domain.Entities;
using SolvexTechnicalTest.Core.Domain.Repositories;
using SolvexTechnicalTest.Infraestructure.Persistence.Base;
using SolvexTechnicalTest.Infraestructure.Persistence.Context;

namespace SolvexTechnicalTest.Infraestructure.Persistence.Repositories
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        private readonly ApplicationContext _context;
        public ColorRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
