using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface ILocationBusiness
    {
        OperationResult<int> DeleteAll();
        OperationResult<IEnumerable<Location>> GetAll();
        OperationResult<Location> GetById(Guid id);

        Task<OperationResult<int>> DeleteAllAsync();
        Task<OperationResult<IEnumerable<Location>>> GetAllAsync();
        Task<OperationResult<Location>> GetByIdAsync(Guid id);
    }
}
