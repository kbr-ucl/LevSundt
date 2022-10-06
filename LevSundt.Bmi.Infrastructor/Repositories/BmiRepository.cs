using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;

namespace LevSundt.Bmi.Infrastructor.Repositories;

public class BmiRepository : IBmiRepository
{
    private readonly LevSundtContext _db;

    public BmiRepository(LevSundtContext db)
    {
        _db = db;
    }

    void IBmiRepository.Add(BmiEntity bmi)
    {
        _db.Add(bmi);
        _db.SaveChanges();
    }



    IEnumerable<BmiQueryResultDto> IBmiRepository.GetAll(string userId)
    {
        foreach (var entity in _db.BmiEntities.AsNoTracking().Where(a => a.UserId == userId).ToList())
            yield return new BmiQueryResultDto
                {Bmi = entity.Bmi, Weight = entity.Weight, Height = entity.Height, Id = entity.Id, Date = entity.Date, RowVersion = entity.RowVersion};
    }

    void IBmiRepository.Update(BmiEntity model)
    {
        _db.Update(model);
        _db.SaveChanges(); 
    }

    BmiEntity IBmiRepository.Load(int id, string userId)
    {
        var dbEntity = _db.BmiEntities.AsNoTracking().FirstOrDefault(a => a.Id == id && a.UserId == userId);
        if(dbEntity == null) throw new Exception("Bmi måling findes ikke i databasen");

        return dbEntity;
    }

    BmiQueryResultDto IBmiRepository.Get(int id, string userId)
    {
        var dbEntity = _db.BmiEntities.AsNoTracking().FirstOrDefault(a => a.Id == id && a.UserId == userId);
        if(dbEntity == null) throw new Exception("Bmi måling findes ikke i databasen");

        return new BmiQueryResultDto
            {Bmi = dbEntity.Bmi, Weight = dbEntity.Weight, Height = dbEntity.Height, Id = dbEntity.Id, Date = dbEntity.Date, RowVersion = dbEntity.RowVersion};
    }
}