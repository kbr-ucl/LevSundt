namespace LevSundt.Bmi.Application.Queries
{
    public interface IBmiGetAllQuery
    {
        IEnumerable<BmiQueryResultDto> GetAll();
    }
}
