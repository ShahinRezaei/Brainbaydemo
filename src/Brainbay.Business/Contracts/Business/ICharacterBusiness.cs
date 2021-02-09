using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface ICharacterBusiness
    {
        OperationResult<int> DeleteAll();
        OperationResult<int> SaveAll(IEnumerable<Character> characters);
        OperationResult<int> SaveCharacter(Character character); 
        OperationResult<IEnumerable<Character>> GetAllCharacters();
        OperationResult<IEnumerable<Character>> GetAllCharacters(Expression<Func<Character, bool>> expression);
        OperationResult<IEnumerable<Character>> GetAllCharactersInclude(Expression<Func<Character, bool>> expression, params string[] navigations);

        Task<OperationResult<int>> DeleteAllAsync();
        Task<OperationResult<int>> SaveAllAsync(IEnumerable<Character> characters);
        Task<OperationResult<int>> SaveCharacterAsync(Character character);
        Task<OperationResult<IEnumerable<Character>>> GetAllCharactersAsync();
        Task<OperationResult<IEnumerable<Character>>> GetAllCharactersAsync(Expression<Func<Character, bool>> expression);
        Task<OperationResult<IEnumerable<Character>>> GetAllCharactersIncludeAsync(Expression<Func<Character, bool>> expression, params string[] navigations);

    }
}