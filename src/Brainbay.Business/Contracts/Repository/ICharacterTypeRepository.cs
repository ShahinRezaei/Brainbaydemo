using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface ICharacterTypeRepository : IUnitOfWork
    {
        void DeleteAllCharacterTypes();
        void DeleteAllCharacterTypes(IEnumerable<Guid> ids);
        void SaveAllCharacterTypes(IEnumerable<CharacterType> characterTypes);
        IQueryable<CharacterType> GetAll(Expression<Func<CharacterType, bool>> expression);
        IQueryable<CharacterType> GetAll();
        CharacterType GetById(Guid id);

        Task DeleteAllCharacterTypesAsync();
        Task DeleteAllCharacterTypesAsync(IEnumerable<Guid> ids);
        Task SaveAllCharacterTypesAsync(IEnumerable<CharacterType> characterTypes);
        Task<IQueryable<CharacterType>> GetAllAsync(Expression<Func<CharacterType, bool>> expression);
        Task<IQueryable<CharacterType>> GetAllAsync();
        Task<CharacterType> GetByIdAsync(Guid id);

    }
}
