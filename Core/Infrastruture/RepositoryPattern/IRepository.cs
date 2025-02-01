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
    public interface IRepository<T>
        where T : Entity
    { 
        public IQueryable<T> Query();

    }
}
