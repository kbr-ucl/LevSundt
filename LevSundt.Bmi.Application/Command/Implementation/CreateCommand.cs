using LevSundt.Bmi.Application.Repository;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Command.Implementation;

public class CreateCommand : ICreateCommand
{
    private readonly IBmiRepository _bmiRepository;

    public CreateCommand(IBmiRepository bmiRepository)
    {
        _bmiRepository = bmiRepository;
    }

    void ICreateCommand.Create(BmiDto bmiDto)
    {
        var id = _bmiRepository.GetNextId();
        var bmi = new BmiEntity(bmiDto.Heigth, bmiDto.Weight, id);
        _bmiRepository.Add(bmi);
    }
}