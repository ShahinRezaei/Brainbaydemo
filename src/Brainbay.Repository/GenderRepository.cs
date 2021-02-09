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
    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllGenders(IEnumerable<Guid> ids)
        {
            DeleteAll(ids); 
        }

        public void DeleteAllGenders()
        {
            Context.Set<Gender>().RemoveRange(Context.Set<Gender>().ToList());
        }


        public IQueryable<Gender> GetAll(Expression<Func<Gender, bool>> expression)
        {
            return FetchAll().Where(expression);
        }

        public IQueryable<Gender> GetAll()
        {
            return FetchAll();
        }
       

        public Gender GetById(Guid id)
        {
            return Context.Set<Gender>().Find(id);
        }

        public void SaveAllGenders(IEnumerable<Gender> genders)
        {
            SaveAll(genders);
        }

        public async Task DeleteAllGendersAsync()
        {
            await DeleteAllAsync();
        }

        public async Task DeleteAllGendersAsync(IEnumerable<Guid> ids)
        {
            await DeleteAllAsync(ids);
        }

        public async Task<IQueryable<Gender>> GetAllAsync(Expression<Func<Gender, bool>> expression)
        {
            return await FetchAllAsync(expression); 
        }

        public async Task<IQueryable<Gender>> GetAllAsync()
        {
            return await FetchAllAsync();
        }

        public async Task<Gender> GetByIdAsync(Guid id)
        {
            return await FetchByIDAsync(id);
        }

        public async Task SaveAllGendersAsync(IEnumerable<Gender> genders)
        {
            await SaveAllAsync(genders); 
        }
    }
}
