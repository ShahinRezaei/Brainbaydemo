using Brainbay.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class EpisodeBusiness : IEpisodeBusiness
    {

        private IEpisodeRepository _episodeRepository;
        public EpisodeBusiness(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository; 
        }

        public OperationResult<int> DeleteAll()
        {
            _episodeRepository.DeleteAllEpisodes();
            var result = _episodeRepository.Commit();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }

        public async Task<OperationResult<int>> DeleteAllAsync()
        {
            await _episodeRepository.DeleteAllEpisodesAsync();
            var result = await _episodeRepository.CommitAsync();
            return new OperationResult<int>() { Message = string.Empty, Status = result > 0 ? OperationStatus.Succeeded : OperationStatus.Failed, Result = result };
        }
    }
}
