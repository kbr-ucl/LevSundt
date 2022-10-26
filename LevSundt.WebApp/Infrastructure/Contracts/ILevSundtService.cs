using LevSundt.WebApp.Infrastructure.Contracts.Dtos;

namespace LevSundt.WebApp.Infrastructure.Contracts
{
    public interface ILevSundtService
    {
        Task Create(BmiCreateRequestDto bmiCreateRequestDto);
        Task Edit(BmiEditRequestDto bmiEditRequestDto);
        Task<IEnumerable<BmiQueryResultDto>?> GetAll(string userId);
        Task<BmiQueryResultDto> Get(int id, string userId);
    }
}
