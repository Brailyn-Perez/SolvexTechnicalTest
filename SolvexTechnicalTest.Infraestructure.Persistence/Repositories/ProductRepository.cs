using SolvexTechnicalTest.Core.Domain.Entities;
using SolvexTechnicalTest.Core.Domain.Repositories;
using SolvexTechnicalTest.Infraestructure.Persistence.Base;
using SolvexTechnicalTest.Infraestructure.Persistence.Context;

namespace SolvexTechnicalTest.Infraestructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
