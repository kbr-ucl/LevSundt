using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Commands.Impementation;

public class CreateBmiCommand : ICreateBmiCommand
{
    private readonly IBmiRepository _bmiRepository;

    public CreateBmiCommand(IBmiRepository bmiRepository)
    {
        _bmiRepository = bmiRepository;
    }
    void ICreateBmiCommand.Create(BmiCreateRequestDto bmiCreateRequestDto)
    {
        var id = _bmiRepository.GetNextKey();
        var bmi = new BmiEntity(bmiCreateRequestDto.Height, bmiCreateRequestDto.Weight, id);
        _bmiRepository.Add(bmi);
    }
}