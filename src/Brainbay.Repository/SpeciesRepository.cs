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
    public class SpeciesRepository : RepositoryBase<Species>, ISpeciesRepository
    {
        public SpeciesRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllSpecies(IEnumerable<Guid> ids)
        {
            DeleteAll(ids);
        }

        public void DeleteAllSpecies()
        {
            Context.Set<Species>().RemoveRange(Context.Set<Species>().ToList());
        }

        public IQueryable<Species> GetAll(Expression<Func<Species, bool>> expression)
        {
            return FetchAll().Where(expression);
        }

        public IQueryable<Species> GetAll()
        {
            return FetchAll();
        }

        public Species GetById(Guid id)
        {
            return Context.Set<Species>().Find(id);
        }

        public void SaveAllSpecies(IEnumerable<Species> species)
        {
            SaveAll(species);
        }

        public async Task DeleteAllSpeciesAsync()
        {
            await DeleteAllAsync(); 
        }

        public async Task DeleteAllSpeciesAsync(IEnumerable<Guid> ids)
        {
            await DeleteAllAsync(ids);
        }

        public async Task<IQueryable<Species>> GetAllAsync(Expression<Func<Species, bool>> expression)
        {
            return await FetchAllAsync(expression); 
        }

        public async Task<IQueryable<Species>> GetAllAsync()
        {
            return await FetchAllAsync(); 
        }

        public async Task<Species> GetByIdAsync(Guid id)
        {
            return await FetchByIDAsync(id);
        }

        public async Task SaveAllSpeciesAsync(IEnumerable<Species> species)
        {
            await SaveAllAsync(species);
        }
    }
}
