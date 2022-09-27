using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Commands.Impementation;

public class CreateBmiCommand : ICreateBmiCommand
{
    private readonly IBmiRepository _bmiRepository;
    private readonly IBmiDomainService _domainService;

    public CreateBmiCommand(IBmiRepository bmiRepository, IBmiDomainService domainService)
    {
        _bmiRepository = bmiRepository;
        _domainService = domainService;
    }
    void ICreateBmiCommand.Create(BmiCreateRequestDto bmiCreateRequestDto)
    {
        var bmi = new BmiEntity(_domainService, bmiCreateRequestDto.Height, bmiCreateRequestDto.Weight);
        _bmiRepository.Add(bmi);
    }
}