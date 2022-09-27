using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Infrastructor.Repositories;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;

namespace LevSundt.Bmi.Infrastructor.DomainServices;

public class BmiDomainService : IBmiDomainService
{
    private readonly LevSundtContext _db;

    public BmiDomainService(LevSundtContext db)
    {
        _db = db;
    }

    bool IBmiDomainService.BmiExsistsOnDate(DateTime date)
    {
        return _db.BmiEntities.AsNoTracking().ToList().Any(a => a.Date.Date == date.Date);
    }
}