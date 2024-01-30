using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrganicShop.Domain;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Repositories
{
    public abstract class CrudRepository<TEntity, TKey> :
        IReadRepository<TEntity, TKey>
        ,IWriteRepository<TEntity, TKey>
        ,IDeleteRepository<TEntity, TKey>
        where TEntity : EntityId<TKey>, IAggregateRoot
        where TKey : struct
    {

        public required OrganicShopDbContext _context { protected get; init; }


        public async Task<TKey> Add(TEntity entity, long id)
        {
            entity.SoftDelete = new SoftDelete { IsDelete = false, DalateDate = null };
            entity.BaseEntity = new BaseEntity { CreateDate = DateTime.Now, LastModified = DateTime.Now, IsActive = true };
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = entity.GetType().Name,
                Type = Domain.Enums.OperationType.Create,
                UserId = id,
            };
            await _context.AddAsync(entity);
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Add(List<TEntity> entities, long id)
        {
            foreach (var entity in entities)
            {
                entity.SoftDelete = new SoftDelete { IsDelete = false, DalateDate = null };
                entity.BaseEntity = new BaseEntity { CreateDate = DateTime.Now, LastModified = DateTime.Now, IsActive = true };
            }
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = entities.GetType().Name,
                Type = Domain.Enums.OperationType.Create,
                UserId = id,
            };
            await _context.AddRangeAsync(entities);
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity, long id)
        {
            entity.BaseEntity.LastModified = DateTime.Now;
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = entity.GetType().Name,
                Type = Domain.Enums.OperationType.Update,
                UserId = id,
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNoTrackng(TEntity entity, long id)
        {
            entity.BaseEntity.LastModified = DateTime.Now;
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = entity.GetType().Name,
                Type = Domain.Enums.OperationType.Update,
                UserId = id,
            };
            _context.Update(entity);
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }


        public async Task SoftDelete(TEntity entity, long id)
        {
            _context.Entry(entity).Entity.SoftDelete.DalateDate = DateTime.Now;
            _context.Entry(entity).Entity.SoftDelete.IsDelete = true;
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = entity.GetType().Name,
                Type = Domain.Enums.OperationType.SoftDelete,
                UserId = id,
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDelete(TKey key, long id)
        {
            TEntity entity = await GetAsNoTracking(key);
            _context.Entry(entity).Entity.SoftDelete.DalateDate = DateTime.Now;
            _context.Entry(entity).Entity.SoftDelete.IsDelete = true;
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = entity.GetType().Name,
                Type = Domain.Enums.OperationType.SoftDelete,
                UserId = id,
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity?> GetAsNoTracking(TKey id)
        {
            return await _context
                        .Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public virtual async Task<TEntity?> GetAsTracking(TKey id)
        {
            return await _context
                        .Set<TEntity>()
                        .AsTracking()
                        .FirstOrDefaultAsync(a => a.Id.Equals(id));
        }


        public IQueryable<TEntity> GetQueryable()
        {
            return _context
                  .Set<TEntity>()
                  .AsNoTracking()
                  .AsQueryable();
        }


        public async Task Delete(TEntity entity, long id)
        {
            _context.Remove(entity);
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = entity.GetType().Name,
                Type = Domain.Enums.OperationType.SoftDelete,
                UserId = id,
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TKey key, long id)
        {
            TEntity entity = await GetAsNoTracking(key);
            _context.Remove(entity);
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = entity.GetType().Name,
                Type = Domain.Enums.OperationType.SoftDelete,
                UserId = id,
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        => _context.Dispose();

        public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();

        public async Task SaveChanges()
        => await _context.SaveChangesAsync();

    }
}
