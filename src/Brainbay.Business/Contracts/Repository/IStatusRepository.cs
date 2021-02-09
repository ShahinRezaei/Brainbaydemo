using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IStatusRepository : IUnitOfWork
    {
        void DeleteAllStatuses();
        void DeleteAllStatuses(IEnumerable<Guid> ids);
        void SaveAllStatues(IEnumerable<Status> statuses);
        IQueryable<Status> GetAll(Expression<Func<Status, bool>> expression);
        IQueryable<Status> GetAll();
        Status GetById(Guid id);

        Task DeleteAllStatusesAsync();
        Task DeleteAllStatusesAsync(IEnumerable<Guid> ids);
        Task SaveAllStatuesAsync(IEnumerable<Status> statuses);
        Task<IQueryable<Status>> GetAllAsync(Expression<Func<Status, bool>> expression);
        Task<IQueryable<Status>> GetAllAsync();
        Task<Status> GetByIdAsync(Guid id);
    }
}
