using SolvexTechnicalTest.Core.Domain.Common;

namespace SolvexTechnicalTest.Core.Domain.Entities
{
    public class Color : AuditableEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string HexCode { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
