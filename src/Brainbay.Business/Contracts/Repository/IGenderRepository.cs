using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IGenderRepository :  IUnitOfWork
    {
        void DeleteAllGenders();
        void DeleteAllGenders(IEnumerable<Guid> ids);
        void SaveAllGenders(IEnumerable<Gender> genders);
        IQueryable<Gender> GetAll(Expression<Func<Gender, bool>> expression);
        IQueryable<Gender> GetAll();
        Gender GetById(Guid id);
        Task DeleteAllGendersAsync();
        Task DeleteAllGendersAsync(IEnumerable<Guid> ids);
        Task SaveAllGendersAsync(IEnumerable<Gender> genders);
        Task<IQueryable<Gender>> GetAllAsync(Expression<Func<Gender, bool>> expression);
        Task<IQueryable<Gender>> GetAllAsync();
        Task<Gender> GetByIdAsync(Guid id);
    }
}
