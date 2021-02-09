using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IGenderBusiness 
    {
        OperationResult<int> DeleteAll();
        OperationResult<IEnumerable<Gender>> GetAll();
        OperationResult<Gender> GetById(Guid id);

        Task<OperationResult<int>> DeleteAllAsync();
        Task<OperationResult<IEnumerable<Gender>>> GetAllAsync();
        Task<OperationResult<Gender>> GetByIdAsync(Guid id);
    }
}
