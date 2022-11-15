using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LevSundt.Crosscut.TransactionHandling.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _db;
        private IDbContextTransaction _transcation;

        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
        {
            _transcation = _db.Database.CurrentTransaction ?? _db.Database.BeginTransaction(isolationLevel);
        }

        void IUnitOfWork.Commit()
        {
            _transcation.Commit();
            _transcation.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            _transcation.Rollback();
            _transcation.Dispose();
        }
    }
}
