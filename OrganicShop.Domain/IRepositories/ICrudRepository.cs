using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IRepositories
{
    public interface ICrudRepository<TEntity, TKey> : IDisposable , IAsyncDisposable
        where TEntity : EntityId<TKey>, IAggregateRoot 
        where TKey : struct
    {

    }


    public interface IReadRepository<TEntity,TKey> : ICrudRepository<TEntity,TKey>
        where TEntity : EntityId<TKey>,IAggregateRoot 
        where TKey : struct
    {
        IQueryable<TEntity> GetQueryable();
        Task<TEntity?> GetAsNoTracking(TKey key);
    }


    public interface IWriteRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
        where TEntity : EntityId<TKey>, IAggregateRoot
        where TKey : struct
    {
        Task<TKey> Add(TEntity entity, long id);
        Task Add(List<TEntity> entities, long id);
        Task Update(TEntity entity, long id);
        Task UpdateNoTrackng(TEntity entity, long id);
        Task SoftDelete(TEntity entity, long id);
        Task SoftDelete(TKey entity, long id);
        Task<TEntity?> GetAsTracking(TKey key);
        //Task SaveChanges();
    }


    public interface IDeleteRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
      where TEntity : EntityId<TKey>, IAggregateRoot
      where TKey : struct
    {
        Task Delete(TEntity entity, long id);
        Task Delete(TKey entity, long id);
        //Task SaveChanges();

    }
}
