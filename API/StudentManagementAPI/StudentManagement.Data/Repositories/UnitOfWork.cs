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
    }
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
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

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
