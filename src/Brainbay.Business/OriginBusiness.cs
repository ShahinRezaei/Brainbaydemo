using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class OriginBusiness : IOriginBusiness
    {
        private IOriginRepository _originRepository;
        public OriginBusiness(IOriginRepository originRepository)
        {
            _originRepository = originRepository; 
        }

        public OperationResult<int> DeleteAll()
        {
            _originRepository.DeleteAllOrigins();
            var result = _originRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }


        public OperationResult<IEnumerable<Origin>> GetAllOrigins()
        {
            var result = _originRepository.GetAllOrigins();
            return new OperationResult<IEnumerable<Origin>>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result };
        }

        public OperationResult<Origin> GetById(Guid id)
        {
            var result = _originRepository.GetById(id);
            return new OperationResult<Origin>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }


        public async Task<OperationResult<int>> DeleteAllAsync()
        {
            await _originRepository.DeleteAllOriginsAsync();
            var result = await _originRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public async Task<OperationResult<IEnumerable<Origin>>> GetAllOriginsAsync()
        {
            var result = await _originRepository.GetAllOriginsAsync();
            return new OperationResult<IEnumerable<Origin>>() { Message = string.Empty, Status = OperationStatus.Succeeded, Result = result };
        }

       
        public async Task<OperationResult<Origin>> GetByIdAsync(Guid id)
        {
            var result = await _originRepository.GetByIdAsync(id);
            return new OperationResult<Origin>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }
    }
}
