using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IOriginBusiness
    {
        OperationResult<int> DeleteAll();
        OperationResult<IEnumerable<Origin>> GetAllOrigins();
        OperationResult<Origin> GetById(Guid id);
        Task<OperationResult<int>> DeleteAllAsync();
        Task<OperationResult<IEnumerable<Origin>>> GetAllOriginsAsync();
        Task<OperationResult<Origin>> GetByIdAsync(Guid id);
    }
}