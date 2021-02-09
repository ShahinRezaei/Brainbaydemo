using Brainbay.Business;
using Brainbay.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllLocations(IEnumerable<Guid> ids)
        {
            DeleteAll(ids); 
        }

        public void DeleteAllLocations()
        {
            Context.Set<Location>().RemoveRange(Context.Set<Location>().ToList());
        }


        public IQueryable<Location> GetAll(Expression<Func<Location, bool>> expression)
        {
            return FetchAll().Where(expression);
        }

        public IQueryable<Location> GetAll()
        {
            return FetchAll();
        }
        
        public Location GetById(Guid id)
        {
            return FetchByID(id); 
        }

        public void SaveAllLocations(IEnumerable<Location> locations)
        {
            SaveAll(locations);
        }


        public async Task DeleteAllLocationsAsync()
        {
            await DeleteAllAsync();
        }

        public async Task DeleteAllLocationsAsync(IEnumerable<Guid> ids)
        {
            await DeleteAllAsync(ids);
        }

        public async Task<IQueryable<Location>> GetAllAsync(Expression<Func<Location, bool>> expression)
        {
            return await FetchAllAsync(expression);
        }

        public async Task<IQueryable<Location>> GetAllAsync()
        {
            return await FetchAllAsync(); 
        }


        public async Task<Location> GetByIdAsync(Guid id)
        {
            return await FetchByIDAsync(id);
        }

        public async Task SaveAllLocationsAsync(IEnumerable<Location> locations)
        {
            await SaveAllAsync(locations);
        }
    }
}
