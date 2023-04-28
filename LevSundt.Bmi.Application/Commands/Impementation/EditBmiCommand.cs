using System.Data;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;
using LevSundt.Crosscut.TransactionHandling;

namespace LevSundt.Bmi.Application.Commands.Impementation;

public class EditBmiCommand : IEditBmiCommand
{
    private readonly IBmiRepository _repository;
    private readonly IUnitOfWork _uow;

    public EditBmiCommand(IBmiRepository repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
    }
    void IEditBmiCommand.Edit(BmiEditRequestDto requestDto)
    {



        try
        {
            _uow.BeginTransaction(IsolationLevel.Serializable);
            
            // Read
            var model = _repository.Load(requestDto.Id, requestDto.UserId);
            
            // DoIt
            model.Edit(requestDto.Weight, requestDto.Height, requestDto.RowVersion);

            // Save
            _repository.Update(model);

            _uow.Commit();
        }
        catch
        {
            _uow.Rollback();
            throw;
        }
    }
}