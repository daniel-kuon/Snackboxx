using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Core.DatabaseModel;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Core
{
    public class EntityService<T> where T : class, IEntity, new()
    {
        protected readonly DataContext Context;

        public EntityService(DataContext context)
        {
            Context = context;
        }

        private IQueryable<T> GetInternalAsync(bool asNoTrackable, bool expand, bool includeNonPublicData)
        {
            IQueryable<T> set = Context.Set<T>();
            if (asNoTrackable)
                set = set.AsNoTracking();
            if (expand)
            {
                if (typeof(T) == typeof(ApplicationUser))
                    set = (IQueryable<T>) ((IQueryable<ApplicationUser>) set).AddDefaultIncludes();
                else if (typeof(T) == typeof(Product))
                    set = (IQueryable<T>) ((IQueryable<Product>) set).AddDefaultIncludes(includeNonPublicData);
                else if (typeof(T) == typeof(Achievement))
                    set = (IQueryable<T>) ((IQueryable<Achievement>) set).AddDefaultIncludes();
                else if (typeof(T) == typeof(Purchase))
                    set = (IQueryable<T>) ((IQueryable<Purchase>) set).AddDefaultIncludes();
                else if (typeof(T) == typeof(ProductVoting))
                    set = (IQueryable<T>) ((IQueryable<ProductVoting>) set).AddDefaultIncludes();
            }

            return set;
        }

        public virtual Task<bool> Exists(Guid id)
        {
            return Exists<T>(id);
        }

        public virtual async Task EnsureExists(Guid id)
        {
            await EnsureExists<T>(id);
        }

        public virtual Task<bool> Exists<T>(Guid id) where T: class, IEntity
        {
            return Context.Set<T>()
                .AsNoTracking()
                .AnyAsync(e => e.Id == id);
        }

        public virtual async Task EnsureExists<T>(Guid id)where T: class, IEntity
        {
            if (!await Exists(id))
                throw new EntityNotFoundException<T>(id);
        }

        public virtual Task<List<T>> GetWithTrackingAsync(bool expand = true, bool includeNonPublicData = false)
        {
            return GetInternalAsync(false, expand, includeNonPublicData)
                .ToListAsync();
        }

        public virtual Task<List<T>> GetAsync(bool expand = true, bool includeNonPublicData = false)
        {
            return GetInternalAsync(true, expand, includeNonPublicData)
                .ToListAsync();
        }

        public virtual Task<T> GetWithTrackingAsync(Guid id, bool expand = true, bool includeNonPublicData = false)
        {
            var entity = GetInternalAsync(false, expand, includeNonPublicData)
                .SingleOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                throw new EntityNotFoundException<T>(id);
            return entity;
        }

        public virtual Task<T> GetAsync(Guid id, bool expand = true, bool includeNonPublicData = false)
        {
            var entity = GetInternalAsync(true, expand, includeNonPublicData)
                .SingleOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                throw new EntityNotFoundException<T>(id);
            return entity;
        }

        protected async Task<T> GetAsync<T>(Guid id) where T : class, IEntity
        {
            var entity = await Context.FindAsync<T>(id);
            if (entity == null) 
                throw new EntityNotFoundException<T>();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await EnsureExists(entity.Id);
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            if (entity.Id != Guid.Empty && await Exists(entity.Id))
                throw new Exception($"{typeof(T).Name} with key {entity.Id} already exists");
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            await EnsureExists(entity.Id);
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}