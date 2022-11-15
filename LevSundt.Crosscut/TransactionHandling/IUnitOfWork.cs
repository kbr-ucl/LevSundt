using System.Data;

namespace LevSundt.Crosscut.TransactionHandling;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction(IsolationLevel isolationLevel);
}