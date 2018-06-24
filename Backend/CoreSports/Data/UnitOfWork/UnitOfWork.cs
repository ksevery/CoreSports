using System;
using System.Linq;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IRepository<ApplicationUser> ApplicationUsers => new GenericRepository<ApplicationUser>(_dbContext);
        public IRepository<Event> Events => new GenericRepository<Event>(_dbContext);
        public IRepository<Market> Markets => new GenericRepository<Market>(_dbContext);
        public IRepository<Selection> Selections => new GenericRepository<Selection>(_dbContext);
        public IRepository<UserBet> UserBets => new GenericRepository<UserBet>(_dbContext);

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
