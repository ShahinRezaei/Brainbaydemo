using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public interface IDataLoader<T>
        where T : class, new()
    {

        event EventHandler BeforeDataLoad;
        event EventHandler AfterDataLoad;
        Task<IList<T>> LoadDataAsync(string requestUri); 
    }
}
