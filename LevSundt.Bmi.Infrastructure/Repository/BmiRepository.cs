using LevSundt.Bmi.Application.Repository;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Infrastructure.Repository;

public class BmiRepository : IBmiRepository
{
    private static readonly Dictionary<int, BmiEntity> _database = new();

    void IBmiRepository.Add(BmiEntity bmi)
    {
        _database.Add(bmi.Id, bmi);
    }

    int IBmiRepository.GetNextId()
    {
        return _database.Keys.Max() + 1;
    }
}