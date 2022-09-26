using LevSundt.Bmi.Application.Repositories;

namespace LevSundt.Bmi.Application.Commands.Impementation;

public class EditBmiCommand : IEditBmiCommand
{
    private readonly IBmiRepository _repository;

    public EditBmiCommand(IBmiRepository repository)
    {
        _repository = repository;
    }
    void IEditBmiCommand.Edit(BmiEditRequestDto requestDto)
    {
        // Read
        var model = _repository.Load(requestDto.Id);
        // DoIt

        model.Edit(requestDto.Weight, requestDto.Height);

        // Save
        _repository.Update(model);
    }
}