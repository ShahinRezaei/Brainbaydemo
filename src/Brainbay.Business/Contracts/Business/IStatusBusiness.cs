using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IStatusBusiness
    {
        OperationResult<int> DeleteAll();
        OperationResult<IEnumerable<Status>> GetAll();
        OperationResult<Status> GetById(Guid id);
        Task<OperationResult<int>> DeleteAllAsync();
        Task<OperationResult<IEnumerable<Status>>> GetAllAsync();
        Task<OperationResult<Status>> GetByIdAsync(Guid id);
    }
}