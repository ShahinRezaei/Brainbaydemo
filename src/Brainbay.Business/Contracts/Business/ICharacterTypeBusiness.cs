using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface ICharacterTypeBusiness
    {
        OperationResult<int> DeleteAll();
        OperationResult<IEnumerable<CharacterType>> GetAll();
        OperationResult<CharacterType> GetById(Guid id);
        Task<OperationResult<int>> DeleteAllAsync();
        Task<OperationResult<IEnumerable<CharacterType>>> GetAllAsync();
        Task<OperationResult<CharacterType>> GetByIdAsync(Guid id);
    }
}
