using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class GenderBusiness : IGenderBusiness
    {
        private IGenderRepository _genderRepository;

        public GenderBusiness(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public OperationResult<int> DeleteAll()
        {
            _genderRepository.DeleteAllGenders();
            var result = _genderRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public OperationResult<IEnumerable<Gender>> GetAll()
        {
            var result = _genderRepository.GetAll().ToList();
            return new OperationResult<IEnumerable<Gender>>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }
        public OperationResult<Gender> GetById(Guid id)
        {
            var result = _genderRepository.GetById(id);
            return new OperationResult<Gender>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }


        public async Task<OperationResult<int>> DeleteAllAsync()
        {
            await _genderRepository.DeleteAllGendersAsync();
            var result = await _genderRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public async Task<OperationResult<IEnumerable<Gender>>> GetAllAsync()
        {
            var result = await _genderRepository.GetAllAsync();
            return new OperationResult<IEnumerable<Gender>>() { Message = string.Empty, Result = result.ToList(), Status = OperationStatus.Succeeded };
        }

        
        public async Task<OperationResult<Gender>> GetByIdAsync(Guid id)
        {
            var result = await _genderRepository.GetByIdAsync(id);
            return new OperationResult<Gender>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }
    }
}
