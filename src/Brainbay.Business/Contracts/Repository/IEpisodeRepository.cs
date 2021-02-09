using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IEpisodeRepository : IUnitOfWork
    {
        void DeleteAllEpisodes();
        void DeleteAllEpisodes(IEnumerable<Guid> ids);
        void SaveAllEpisodes(IEnumerable<Episode> episodes);
        Task DeleteAllEpisodesAsync();
        Task DeleteAllEpisodesAsync(IEnumerable<Guid> ids);
        Task SaveAllEpisodesAsync(IEnumerable<Episode> episodes);
    }
}
