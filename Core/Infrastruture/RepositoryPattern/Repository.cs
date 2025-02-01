using Core.Infrastruture.UnitOfWork;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastruture.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly PersonDetailsDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public Repository(PersonDetailsDBContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
            _unitOfWork = new UnitOfWork.UnitOfWork(context);
        }
        
       

        public IQueryable<T> Query()
            => _dbContext.Set<T>().AsQueryable();

    }
}
