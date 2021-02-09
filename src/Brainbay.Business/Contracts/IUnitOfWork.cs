using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IUnitOfWork 
    {
        int Commit();
        Task<int> CommitAsync(); 
    }
}
