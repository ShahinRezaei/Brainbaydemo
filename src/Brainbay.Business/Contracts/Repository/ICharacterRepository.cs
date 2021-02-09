using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface ICharacterRepository : IUnitOfWork
    {
        IQueryable<Character> GetCharacters(Expression<Func<Character, bool>> expression);
        void DeleteAllCharacters();
        void DeleteAllCharacters(IEnumerable<int> ids);
        void SaveAllCharacters(IEnumerable<Character> characters);
        void SaveCharacter(Character character);
        IQueryable<Character> GetAllCharacters();
        IQueryable<Character> GetAllCharacters(Expression<Func<Character, bool>> expression, params string[] navigations);

        Task<IQueryable<Character>> GetCharactersAsync(Expression<Func<Character, bool>> expression);
        Task DeleteAllCharactersAsync();
        Task DeleteAllCharactersAsync(IEnumerable<int> ids);
        Task SaveAllCharactersAsync(IEnumerable<Character> characters);
        Task SaveCharacterAsync(Character character);
        Task<IQueryable<Character>> GetAllCharactersAsync();
        Task<IQueryable<Character>> GetAllCharactersAsync(Expression<Func<Character, bool>> expression, params string[] navigations);
    }
}
