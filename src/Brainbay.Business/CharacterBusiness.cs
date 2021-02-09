using Brainbay.Common;
using Brainbay.Common.Entities;
using Microsoft.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class CharacterBusiness : ICharacterBusiness
    {
        private ICharacterRepository _characterRepository;
        
        public CharacterBusiness(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository; 
        }

        public OperationResult<int> DeleteAll()
        {
            _characterRepository.DeleteAllCharacters();
            var result = _characterRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public OperationResult<int> SaveAll(IEnumerable<Character> characters)
        {
            _characterRepository.SaveAllCharacters(characters);
            var result = _characterRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result };
        }

        public OperationResult<IEnumerable<Character>> GetAllCharacters()
        {
            var result =  _characterRepository.GetAllCharacters().ToList();
            return new OperationResult<IEnumerable<Character>>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result }; 
        }

        public OperationResult<int> SaveCharacter(Character character)
        {
             _characterRepository.SaveCharacter(character);
            var result = _characterRepository.Commit();

            return new OperationResult<int>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result };
        }

        public OperationResult<IEnumerable<Character>> GetAllCharacters(Expression<Func<Character, bool>> expression)
        {
            var result =  _characterRepository.GetCharacters(expression).ToList();
            return new OperationResult<IEnumerable<Character>>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result };
        }

        public OperationResult<IEnumerable<Character>> GetAllCharactersInclude(Expression<Func<Character, bool>> expression, params string [] navigationPath)
        {
            var result = _characterRepository.GetAllCharacters(expression, navigationPath).ToList();
            return new OperationResult<IEnumerable<Character>>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result };
        }

        public async Task<OperationResult<int>> DeleteAllAsync()
        {
            await _characterRepository.DeleteAllCharactersAsync();
            var result = await _characterRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public async Task<OperationResult<int>> SaveAllAsync(IEnumerable<Character> characters)
        {
            await _characterRepository.SaveAllCharactersAsync(characters);
            var result = await _characterRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result };
        }

        public async Task<OperationResult<int>> SaveCharacterAsync(Character character)
        {
            _characterRepository.SaveCharacterAsync(character);
            var result = await _characterRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result };
        }

        public async Task<OperationResult<IEnumerable<Character>>> GetAllCharactersAsync()
        {
            var result = await _characterRepository.GetAllCharactersAsync();
            return new OperationResult<IEnumerable<Character>>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result.ToList() };
        }

        public async Task<OperationResult<IEnumerable<Character>>> GetAllCharactersAsync(Expression<Func<Character, bool>> expression)
        {
            var result = await _characterRepository.GetCharactersAsync(expression);
            return new OperationResult<IEnumerable<Character>>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result.ToList() };
        }

        public async Task<OperationResult<IEnumerable<Character>>> GetAllCharactersIncludeAsync(Expression<Func<Character, bool>> expression, params string[] navigations)
        {
            var result = await _characterRepository.GetAllCharactersAsync(expression, navigations);
            return new OperationResult<IEnumerable<Character>>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result.ToList() };
        }
    }
}
