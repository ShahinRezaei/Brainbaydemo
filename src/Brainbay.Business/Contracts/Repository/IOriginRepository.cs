using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IOriginRepository : IUnitOfWork
    {
        void DeleteAllOrigins();
        void DeleteAllOrigins(IEnumerable<Guid> ids);
        void SaveAllOrigins(IEnumerable<Origin> origins);
        IQueryable<Origin> GetAllOrigins();
        IQueryable<Origin> GetAll(Expression<Func<Origin, bool>> expression);
        Origin GetById(Guid id);
        Task DeleteAllOriginsAsync();
        Task DeleteAllOriginsAsync(IEnumerable<Guid> ids);
        Task SaveAllOriginsAsync(IEnumerable<Origin> origins);
        Task<IQueryable<Origin>> GetAllOriginsAsync();
        Task<IQueryable<Origin>> GetAllAsync(Expression<Func<Origin, bool>> expression);
        Task<Origin> GetByIdAsync(Guid id);
    }
}
