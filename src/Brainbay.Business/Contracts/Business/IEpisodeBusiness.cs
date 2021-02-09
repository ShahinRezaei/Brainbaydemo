using Brainbay.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IEpisodeBusiness 
    {
        OperationResult<int> DeleteAll();
        Task<OperationResult<int>> DeleteAllAsync();
    }
}
