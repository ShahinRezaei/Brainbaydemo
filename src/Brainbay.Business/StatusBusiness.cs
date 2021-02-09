using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class StatusBusiness : IStatusBusiness
    {
        private IStatusRepository _statusRepository;  

        public StatusBusiness(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository; 
        }

        public OperationResult<int> DeleteAll()
        {
            _statusRepository.DeleteAllStatuses();
            var result = _statusRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }
        public OperationResult<IEnumerable<Status>> GetAll()
        {
            var result = _statusRepository.GetAll().ToList();
            return new OperationResult<IEnumerable<Status>>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded }; 
        }
        public OperationResult<Status> GetById(Guid id)
        {
            var result = _statusRepository.GetById(id);
            return new OperationResult<Status>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }



        public async Task<OperationResult<int>> DeleteAllAsync()
        {
            await _statusRepository.DeleteAllStatusesAsync();
            var result = await _statusRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public async Task<OperationResult<IEnumerable<Status>>> GetAllAsync()
        {
            var result = await _statusRepository.GetAllAsync();
            return new OperationResult<IEnumerable<Status>>() { Message = string.Empty, Result = result.ToList(), Status = OperationStatus.Succeeded };
        }

        public async Task<OperationResult<Status>> GetByIdAsync(Guid id)
        {
            var result = await _statusRepository.GetByIdAsync(id);
            return new OperationResult<Status>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }
    }
}
