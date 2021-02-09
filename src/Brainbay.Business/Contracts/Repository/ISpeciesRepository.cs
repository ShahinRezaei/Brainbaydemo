using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface ISpeciesRepository : IUnitOfWork
    {
        void DeleteAllSpecies();
        void DeleteAllSpecies(IEnumerable<Guid> ids);
        void SaveAllSpecies(IEnumerable<Species> species);
        IQueryable<Species> GetAll(Expression<Func<Species, bool>> expression);
        IQueryable<Species> GetAll();
        Species GetById(Guid id);
        Task DeleteAllSpeciesAsync();
        Task DeleteAllSpeciesAsync(IEnumerable<Guid> ids);
        Task SaveAllSpeciesAsync(IEnumerable<Species> species);
        Task<IQueryable<Species>> GetAllAsync(Expression<Func<Species, bool>> expression);
        Task<IQueryable<Species>> GetAllAsync();
        Task<Species> GetByIdAsync(Guid id);
    }
}
