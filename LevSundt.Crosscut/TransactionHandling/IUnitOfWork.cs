using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LevSundt.Crosscut.TransactionHandling;

// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-interfaces
public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction(IsolationLevel isolationLevel);
}

// public class UnitOfWork<T> : IUnitOfWork <T> where T : DbContext
public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _db;
    private IDbContextTransaction _transaction;

    public UnitOfWork(DbContext db)
    {
        _db = db;
    }

    void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
    {
        if(_db.Database.CurrentTransaction != null) return;
        _transaction = _db.Database.BeginTransaction(
            isolationLevel ?? 
            IsolationLevel.Serializable);
    }

    void IUnitOfWork.Commit()
    {
        _transaction.Commit();
        _transaction.Dispose();
    }

    void IUnitOfWork.Rollback()
    {
        _transaction.Rollback();
        _transaction.Dispose();
    }
}