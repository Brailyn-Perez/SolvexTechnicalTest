using SolvexTechnicalTest.Core.Domain.Common;

namespace SolvexTechnicalTest.Core.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public IEnumerable<Color> Colors { get; set; } = new List<Color>();
    }
}
