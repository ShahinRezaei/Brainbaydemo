using Brainbay.Business;
using Brainbay.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Repository
{
    public class OriginRepository : RepositoryBase<Origin>, IOriginRepository
    {
        public OriginRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllOrigins(IEnumerable<Guid> ids)
        {
            DeleteAll(ids);
        }

        public void DeleteAllOrigins()
        {
            Context.Set<Origin>().RemoveRange(Context.Set<Origin>().ToList());
        }

        public IQueryable<Origin> GetAll(Expression<Func<Origin, bool>> expression)
        {
            return FetchAll().Where(expression);
        }


        public IQueryable<Origin> GetAllOrigins()
        {
            return base.FetchAll();
        }

        public Origin GetById(Guid id)
        {
            return Context.Set<Origin>().Find(id);
        }

        public void SaveAllOrigins(IEnumerable<Origin> origins)
        {
            SaveAll(origins);
        }


        public async Task DeleteAllOriginsAsync()
        {
            await DeleteAllAsync();
        }

        public async Task DeleteAllOriginsAsync(IEnumerable<Guid> ids)
        {
            await DeleteAllAsync(ids);
        }

        public async Task<IQueryable<Origin>> GetAllAsync(Expression<Func<Origin, bool>> expression)
        {
            return await FetchAllAsync(expression);
        }

        public async Task<IQueryable<Origin>> GetAllOriginsAsync()
        {
            return await FetchAllAsync(); 
        }


        public async Task<Origin> GetByIdAsync(Guid id)
        {
            return await FetchByIDAsync(id);
        }

        public async Task SaveAllOriginsAsync(IEnumerable<Origin> origins)
        {
            await SaveAllAsync(origins);
        }
    }
}
