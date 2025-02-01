using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Core.Infrastruture.RepositoryPattern;

namespace Core.Infrastruture.UnitOfWork
{
    internal class UnitOfWork(PersonDetailsDBContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        public IRepository<T> Repository<T>() where T : Entity
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new Repository<T>(_dbContext);

            Repositories.Add(typeof(T), repo);
            return repo;
        }

    }
}
