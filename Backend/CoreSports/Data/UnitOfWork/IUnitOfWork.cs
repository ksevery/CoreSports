using System;
using Data.Repositories;
using Models;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }
        IRepository<Event> Events { get; }
        IRepository<Market> Markets { get; }
        IRepository<Selection> Selections { get; }
        IRepository<UserBet> UserBets { get; }

        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
        void Dispose();
    }
}
