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
    public class CharacterTypeRepository : RepositoryBase<CharacterType>, ICharacterTypeRepository
    {
        public CharacterTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllCharacterTypes(IEnumerable<Guid> ids)
        {
            DeleteAll(ids); 
        }

        public void DeleteAllCharacterTypes()
        {
            Context.Set<CharacterType>().RemoveRange(Context.Set<CharacterType>().ToList());
        }


        public IQueryable<CharacterType> GetAll(Expression<Func<CharacterType, bool>> expression)
        {
            return FetchAll();
        }

        public IQueryable<CharacterType> GetAll()
        {
            return FetchAll();
        }

        public CharacterType GetById(Guid id)
        {
            return  Context.Set<CharacterType>().Find(id);
        }

        public void SaveAllCharacterTypes(IEnumerable<CharacterType> characterTypes)
        {
            SaveAll(characterTypes);
        }

        public async Task DeleteAllCharacterTypesAsync()
        {
            await DeleteAllAsync();
        }

        public async Task DeleteAllCharacterTypesAsync(IEnumerable<Guid> ids)
        {
            await DeleteAllAsync(ids);
        }

        public async Task<IQueryable<CharacterType>> GetAllAsync(Expression<Func<CharacterType, bool>> expression)
        {
            return await FetchAllAsync(); 
        }

        public async Task<IQueryable<CharacterType>> GetAllAsync()
        {
            return await FetchAllAsync();
        }

        public async Task<CharacterType> GetByIdAsync(Guid id)
        {
            return await FetchByIDAsync(id);
        }

        public async  Task SaveAllCharacterTypesAsync(IEnumerable<CharacterType> characterTypes)
        {
             await SaveAllAsync(characterTypes);
        }
    }
}
