using PortfolioManagement.Application.DTOs;

namespace PortfolioManagement.Application.Services
{
    public interface IPortofolioService
    {
        Task<IEnumerable<PortofolioDto>> GetUserPortofoliosAsync(string userId);
        Task<PortofolioDto> CreatePortofolioAsync(string userId,  PortofolioDto dto);
    }
}
