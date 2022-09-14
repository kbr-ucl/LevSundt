using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Infrastructor.Repositories;

public class BmiRepository : IBmiRepository
{
    private Dictionary<int, BmiEntity> _database = new();
    
    void IBmiRepository.Add(BmiEntity bmi)
    {
        _database.Add(bmi.Id, bmi);
    }

    int IBmiRepository.GetNextKey()
    {
        if(!_database.Keys.Any()) return 1;

        return _database.Keys.Max() + 1;
    }
}