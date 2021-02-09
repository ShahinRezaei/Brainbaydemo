using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class SpeciesBusiness : ISpeciesBusiness
    {
        private ISpeciesRepository _speciesRepository; 

        public SpeciesBusiness(ISpeciesRepository speciesRepository)
        {
            _speciesRepository = speciesRepository; 
        }


        public OperationResult<int> DeleteAll()
        {
            _speciesRepository.DeleteAllSpecies();
            var result = _speciesRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result }; 
        }

        
        public OperationResult<IEnumerable<Species>> GetAll()
        {
            var result = _speciesRepository.GetAll().ToList();
            return new OperationResult<IEnumerable<Species>>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }

        public OperationResult<Species> GetById(Guid id)
        {
            var result = _speciesRepository.GetById(id);
            return new OperationResult<Species>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }


        public async Task<OperationResult<int>> DeleteAllAsync()
        {
            await _speciesRepository.DeleteAllSpeciesAsync();
            var result = await _speciesRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public async Task<OperationResult<IEnumerable<Species>>> GetAllAsync()
        {
            var result = await _speciesRepository.GetAllAsync();
            return new OperationResult<IEnumerable<Species>>() { Message = string.Empty, Result = result.ToList(), Status = OperationStatus.Succeeded };
        }

        public async Task<OperationResult<Species>> GetByIdAsync(Guid id)
        {
            var result = await _speciesRepository.GetByIdAsync(id);
            return new OperationResult<Species>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }
    }
}
