using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface ILocationRepository : IUnitOfWork
    {
        void DeleteAllLocations();
        void DeleteAllLocations(IEnumerable<Guid> ids);
        void SaveAllLocations(IEnumerable<Location> locations);
        IQueryable<Location> GetAll(Expression<Func<Location, bool>> expression);
        IQueryable<Location> GetAll();
        Location GetById(Guid id);
        Task DeleteAllLocationsAsync();
        Task DeleteAllLocationsAsync(IEnumerable<Guid> ids);
        Task SaveAllLocationsAsync(IEnumerable<Location> locations);
        Task<IQueryable<Location>> GetAllAsync(Expression<Func<Location, bool>> expression);
        Task<IQueryable<Location>> GetAllAsync();
        Task<Location> GetByIdAsync(Guid id);
    }
}
