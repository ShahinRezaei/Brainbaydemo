using Brainbay.Business;
using Brainbay.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Repository
{
    public class EpisodeRepository : RepositoryBase<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void DeleteAllEpisodes(IEnumerable<Guid> ids)
        {
            base.DeleteAll(ids); 
        }

        public void DeleteAllEpisodes()
        {
            Context.Set<Episode>().RemoveRange(Context.Set<Episode>().ToList());
        }

        public async Task DeleteAllEpisodesAsync()
        {
            await DeleteAllAsync();
        }

        public async Task DeleteAllEpisodesAsync(IEnumerable<Guid> ids)
        {
            await DeleteAllAsync(ids);
        }

        public void SaveAllEpisodes(IEnumerable<Episode> episodes)
        {
            base.SaveAll(episodes);
        }

        public async Task SaveAllEpisodesAsync(IEnumerable<Episode> episodes)
        {
            await SaveAllAsync(episodes);
        }
    }
}
