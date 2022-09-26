using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Infrastructor.Repositories;

public class BmiRepository : IBmiRepository
{
    public static readonly Dictionary<int, BmiEntity> _database = new();

    void IBmiRepository.Add(BmiEntity bmi)
    {
        _database.Add(bmi.Id, bmi);
    }



    IEnumerable<BmiQueryResultDto> IBmiRepository.GetAll()
    {
        foreach (var entity in _database.Values)
            yield return new BmiQueryResultDto
                {Bmi = entity.Bmi, Weight = entity.Weight, Height = entity.Height, Id = entity.Id, Date = entity.Date};
    }

    int IBmiRepository.GetNextKey()
    {
        if (!_database.Keys.Any()) return 1;

        return _database.Keys.Max() + 1;
    }

    void IBmiRepository.Update(BmiEntity model)
    {
        _database[model.Id] = model;
        
    }

    BmiEntity IBmiRepository.Load(int id)
    {
        return _database[id];
    }

    BmiQueryResultDto IBmiRepository.Get(int id)
    {
        var dbEnity = _database[id];
        return new BmiQueryResultDto
            {Bmi = dbEnity.Bmi, Weight = dbEnity.Weight, Height = dbEnity.Height, Id = dbEnity.Id, Date = dbEnity.Date};
    }
}