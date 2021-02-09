using Brainbay.Business;
using Brainbay.Common;
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
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllCharacters(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var entity = Context.Set<Character>().Find(ids);
                Context.Entry<Character>(entity).State = EntityState.Deleted;
            }
        }
        public void DeleteAllCharacters()
        {
            DeleteAll(); 
        }
        public IQueryable<Character> GetCharacters(Expression<Func<Character, bool>> expression)
        {
            return FetchAll().Where(expression);
        }
        public void SaveAllCharacters(IEnumerable<Character> characters)
        {
            SaveAll(characters);
        }
        public IQueryable<Character> GetAllCharacters()
        {
            return FetchAll();
        }
        public void SaveCharacter(Character character)
        {
            Save(character);
        }
        public IQueryable<Character> GetAllCharacters(Expression<Func<Character, bool>> expression, params string[] navigations)
        {
            var query = FetchAll();
            foreach (var navigation in navigations)
            {
                query = query.Include(navigation);
            }
            return query.Where(expression);
        }

        public async Task<IQueryable<Character>> GetCharactersAsync(Expression<Func<Character, bool>> expression)
        {
            return await Task.Run<IQueryable<Character>>(() => {
                return Context.Set<Character>().Where(expression);
            });
        }

        public async Task DeleteAllCharactersAsync()
        {
            await DeleteAllAsync(); 
        }

        public async Task DeleteAllCharactersAsync(IEnumerable<int> ids)
        {
            await Task.Run(() => {
                DeleteAllCharacters(ids); 
            });
        }

        public async Task SaveAllCharactersAsync(IEnumerable<Character> characters)
        {
            await SaveAllAsync(characters);
        }

        public async Task SaveCharacterAsync(Character character)
        {
            await SaveAsync(character);
        }

        public async Task<IQueryable<Character>> GetAllCharactersAsync()
        {
            return await base.FetchAllAsync();
        }

        public async Task<IQueryable<Character>> GetAllCharactersAsync(Expression<Func<Character, bool>> expression, params string[] navigations)
        {
            return await FetchAllAsync(expression, navigations); 
        }
    }
}
