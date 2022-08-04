using SERRTraining.UOW.Core.Repositories;
using System.Data;

namespace SERRTraining.UOW.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IDbConnection Connection { get; }

        protected Repository(IDbConnection connection)
        {
            Connection = connection;
        }

        internal virtual dynamic Mapping(TEntity entity)
        {
            return entity;
        }
    }
}