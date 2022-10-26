using LevSundt.WebApp.Infrastructure.Contract.Dto;

namespace LevSundt.WebApp.Infrastructure.Contract;

public interface ILevSundtService
{
    Task Create(BmiCreateRequestDto dto);
    Task Edit(BmiEditRequestDto bmiEditRequestDto);
    Task<BmiQueryResultDto> Get(int id, string identityName);
    Task<IEnumerable<BmiQueryResultDto>> GetAll(string identityName);
}