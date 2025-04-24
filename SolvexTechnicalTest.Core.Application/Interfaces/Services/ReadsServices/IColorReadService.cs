namespace SolvexTechnicalTest.Core.Application.Interfaces.Services.ReadsServices
{
    public interface IColorReadService
    {
        Task<bool> ExistsAsync(int id, CancellationToken ct);
    }
}
