using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Infrastructor.Repositories;

namespace LevSundt.Bmi.Infrastructor.DomainServices;

public class BmiDomainService : IBmiDomainService
{
    bool IBmiDomainService.BmiExsistsOnDate(DateTime date)
    {
        return BmiRepository._database.Values.Any(a => a.Date.Date == date.Date);
    }
}