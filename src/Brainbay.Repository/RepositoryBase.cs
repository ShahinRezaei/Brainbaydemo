using Brainbay.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Repository
{
    public abstract class RepositoryBase<T> : IUnitOfWork
        where T: class, new()
    {
        protected DbContext Context { get; set; }
        public RepositoryBase(DbContext dbContext)
        {
            Context = dbContext; 
        }


        public virtual IQueryable<T> FetchAll()
        {
            return Context.Set<T>().AsQueryable<T>(); 
        }

        public virtual async Task<IQueryable<T>> FetchAllAsync()
        {
            return await Task.Run<IQueryable<T>>(() => {
                return Context.Set<T>().AsQueryable<T>();
            });
        }

        public virtual IQueryable<T> FetchAll(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().AsQueryable<T>();
        }

        public virtual async Task<IQueryable<T>> FetchAllAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run<IQueryable<T>>(() =>
            {
                return FetchAll(expression);
            });
        }

        public virtual IQueryable<T> FetchAll(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query = FetchAll();
            foreach (var navigation in includes)
            {
                query = query.Include(navigation);
            }
            return query.Where(expression);
        }

        public virtual async Task<IQueryable<T>> FetchAllAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            return await Task.Run<IQueryable<T>>(() =>
            {
                return FetchAll(expression,includes);
            });
        }
        public virtual T FetchByID(Guid Id)
        {
            return Context.Set<T>().Find(Id);
        }

        

        public virtual async Task<T> FetchByIDAsync(Guid Id)
        {
            return await Task.Run<T>(() =>
            {
                return FetchByID(Id);
            });
        }

        public virtual void Save(T entity)
        {
            Context.Add<T>(entity);
        }

        public virtual async Task SaveAsync(T entity)
        {
            await Context.AddAsync<T>(entity);
        }

        public virtual void SaveAll(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Save(entity);
            }
        }

        public virtual async Task SaveAllAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                await SaveAsync(entity);
            }
        }

        public virtual void Update(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified; 
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                Context.Entry<T>(entity).State = EntityState.Modified;
            });
        }

        public virtual void UpdateAll(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public virtual async Task UpdateAllAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                await UpdateAsync(entity);
            }
        }

        public virtual void Delete(Guid id)
        {
            var entity = Context.Set<T>().Find(id);
            Context.Entry<T>(entity).State = EntityState.Deleted; 
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            Context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public virtual void DeleteAll(IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                Delete(id);
            }
        }

        public virtual async Task DeleteAllAsync(IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                await DeleteAsync(id);
            }
        }

        public int Commit()
        {
            return Context.SaveChanges(); 
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            Context.Set<T>().RemoveRange(Context.Set<T>().ToList());
        }

        public async Task DeleteAllAsync()
        {
            await Task.Run(() => {
                DeleteAll();
            }); 
        }
    }
}
