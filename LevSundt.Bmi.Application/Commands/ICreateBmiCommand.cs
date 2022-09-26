namespace LevSundt.Bmi.Application.Commands;

public interface ICreateBmiCommand
{
    void Create(BmiCreateRequestDto bmiCreateRequestDto);
}