using SolvexTechnicalTest.Core.Domain.Common;

namespace SolvexTechnicalTest.Core.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public int? ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
