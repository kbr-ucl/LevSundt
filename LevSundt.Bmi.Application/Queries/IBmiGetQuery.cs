namespace LevSundt.Bmi.Application.Queries
{
    public interface IBmiGetQuery
    {
        BmiQueryResultDto Get(int id);
    }
}
