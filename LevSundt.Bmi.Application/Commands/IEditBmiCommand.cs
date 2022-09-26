namespace LevSundt.Bmi.Application.Commands;

public interface IEditBmiCommand
{
    void Edit(BmiEditRequestDto bmiCreateRequestDto);
}