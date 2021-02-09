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
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllStatuses(IEnumerable<Guid> ids)
        {
            DeleteAll(ids); 
        }

        public void DeleteAllStatuses()
        {
            Context.Set<Status>().RemoveRange(Context.Set<Status>().ToList());
        }


        public IQueryable<Status> GetAll(Expression<Func<Status, bool>> expression)
        {
            return FetchAll().Where(expression);
        }

        public IQueryable<Status> GetAll()
        {
            return FetchAll();
        }

        public void SaveAllStatues(IEnumerable<Status> statuses)
        {
            SaveAll(statuses); 
        }

        public Status GetById(Guid id)
        {
            return Context.Set<Status>().Find(id);
        }

        public async Task DeleteAllStatusesAsync()
        {
             await DeleteAllAsync();
        }

        public async Task DeleteAllStatusesAsync(IEnumerable<Guid> ids)
        {
            await DeleteAllAsync(ids);
        }

        public async Task<IQueryable<Status>> GetAllAsync(Expression<Func<Status, bool>> expression)
        {
            return await FetchAllAsync(expression);
        }

        public async Task<IQueryable<Status>> GetAllAsync()
        {
            return await FetchAllAsync();
        }

        public async Task<Status> GetByIdAsync(Guid id)
        {
            return await FetchByIDAsync(id); 
        }

        public async Task SaveAllStatuesAsync(IEnumerable<Status> statuses)
        {
            await SaveAllAsync(statuses);
        }
    }
}
