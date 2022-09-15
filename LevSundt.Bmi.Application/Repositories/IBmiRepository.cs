using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Repositories;

public interface IBmiRepository
{
    void Add(BmiEntity bmi);
    int GetNextKey();
    IEnumerable<BmiQueryResultDto> GetAll();
}