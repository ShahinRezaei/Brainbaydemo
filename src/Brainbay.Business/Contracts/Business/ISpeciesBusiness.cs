using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface ISpeciesBusiness
    {
        OperationResult<int> DeleteAll();
        OperationResult<IEnumerable<Species>> GetAll();
        OperationResult<Species> GetById(Guid id);

        Task<OperationResult<int>> DeleteAllAsync();
        Task<OperationResult<IEnumerable<Species>>> GetAllAsync();
        Task<OperationResult<Species>> GetByIdAsync(Guid id);
    }
}