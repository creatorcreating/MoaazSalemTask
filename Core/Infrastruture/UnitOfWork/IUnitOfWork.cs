using DataLayer;
using Core.Infrastruture.RepositoryPattern;


namespace Core.Infrastruture.UnitOfWork
{
    internal interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : Entity;

    }
}
