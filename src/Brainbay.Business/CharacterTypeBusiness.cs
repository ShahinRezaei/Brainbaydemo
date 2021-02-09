using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class CharacterTypeBusiness : ICharacterTypeBusiness
    {
        private ICharacterTypeRepository _characterTypeRepository; 
        public CharacterTypeBusiness(ICharacterTypeRepository characterTypeRepository)
        {
            _characterTypeRepository = characterTypeRepository;
        }

        public OperationResult<int> DeleteAll()
        {
            _characterTypeRepository.DeleteAllCharacterTypes();
            var result = _characterTypeRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public OperationResult<IEnumerable<CharacterType>> GetAll()
        {
            var result = _characterTypeRepository.GetAll().ToList();
            return new OperationResult<IEnumerable<CharacterType>>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }

        public OperationResult<CharacterType> GetById(Guid id)
        {
            var result = _characterTypeRepository.GetById(id);
            return new OperationResult<CharacterType>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }

        public async Task<OperationResult<int>> DeleteAllAsync()
        {
            await _characterTypeRepository.DeleteAllCharacterTypesAsync();
            var result = await _characterTypeRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public async Task<OperationResult<IEnumerable<CharacterType>>> GetAllAsync()
        {
            var result = await _characterTypeRepository.GetAllAsync();
            return new OperationResult<IEnumerable<CharacterType>>() { Message = string.Empty, Result = result.ToList(), Status = OperationStatus.Succeeded };
        }

        public async Task<OperationResult<CharacterType>> GetByIdAsync(Guid id)
        {
            var result = await _characterTypeRepository.GetByIdAsync(id);
            return new OperationResult<CharacterType>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }
    }
}
