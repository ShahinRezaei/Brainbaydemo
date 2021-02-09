using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class LocationBusiness : ILocationBusiness
    {
        private ILocationRepository _locationRepository;

        public LocationBusiness(ILocationRepository  locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public OperationResult<int> DeleteAll()
        {
            _locationRepository.DeleteAllLocations();
            var result = _locationRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public OperationResult<IEnumerable<Location>> GetAll()
        {
            var result = _locationRepository.GetAll().ToList();
            return new OperationResult<IEnumerable<Location>>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }

        public OperationResult<Location> GetById(Guid id)
        {
            var result = _locationRepository.GetById(id);
            return new OperationResult<Location>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }


        public async Task<OperationResult<int>> DeleteAllAsync()
        {
            await _locationRepository.DeleteAllLocationsAsync();
            var result = await _locationRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }


        public async Task<OperationResult<IEnumerable<Location>>> GetAllAsync()
        {
            var result = await _locationRepository.GetAllAsync();
            return new OperationResult<IEnumerable<Location>>() { Message = string.Empty, Result = result.ToList(), Status = OperationStatus.Succeeded };
        }

        
        public async Task<OperationResult<Location>> GetByIdAsync(Guid id)
        {
            var result = await _locationRepository.GetByIdAsync(id);
            return new OperationResult<Location>() { Message = string.Empty, Result = result, Status = OperationStatus.Succeeded };
        }
    }
}
