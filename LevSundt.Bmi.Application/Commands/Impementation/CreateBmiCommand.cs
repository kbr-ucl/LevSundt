using System.Data;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Domain.Model;
using LevSundt.Crosscut.TransactionHandling;

namespace LevSundt.Bmi.Application.Commands.Impementation;

public class CreateBmiCommand : ICreateBmiCommand
{
    private readonly IBmiRepository _bmiRepository;
    private readonly IBmiDomainService _domainService;
    private readonly IUnitOfWork _uow;

    public CreateBmiCommand(IBmiRepository bmiRepository, IBmiDomainService domainService, IUnitOfWork uow)
    {
        _bmiRepository = bmiRepository;
        _domainService = domainService;
        _uow = uow;
    }

    void ICreateBmiCommand.Create(BmiCreateRequestDto bmiCreateRequestDto)
    {
        try
        {
            _uow.BeginTransaction(IsolationLevel.Serializable);

            var bmi = new BmiEntity(_domainService, bmiCreateRequestDto.Height, bmiCreateRequestDto.Weight,
                bmiCreateRequestDto.UserId);
            _bmiRepository.Add(bmi);

            _uow.Commit();
        }
        catch
        {
            _uow.Rollback();
            throw;
        }
    }
}