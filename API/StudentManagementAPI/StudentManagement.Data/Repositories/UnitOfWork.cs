using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Data.Repository
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
    }
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly SMSContext dbContext;

        public UnitOfWork(SMSContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            dbContext.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
