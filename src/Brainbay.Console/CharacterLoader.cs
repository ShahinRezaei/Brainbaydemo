using Brainbay.Common;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Brainbay.Business;

namespace Brainbay.App
{
    public class CharacterLoader : IDataLoader<CharacterDto>
    {
        public event EventHandler BeforeDataLoad;
        public event EventHandler AfterDataLoad;

        public async Task<IList<CharacterDto>> LoadDataAsync(string requestUri)
        {
            BeforeDataLoad?.Invoke(this, new EventArgs()); 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(requestUri);
                var result = new HttpResult() { info = new HttpRequestInfo() { Next = "https://rickandmortyapi.com/api/character/?page=1" } };
                var characters = new List<CharacterDto>();

                do
                {
                    try
                    {
                        var response = await client.GetAsync(string.Format("character/?page={0}", result.info.Next.Split('=')[1]));

                        if (response.IsSuccessStatusCode)
                        {
                            result = await response.Content.ReadAsAsync<HttpResult>();
                            if (result.results != null)
                            {
                                if (result.results.Length > 0)
                                {
                                    characters.AddRange(result.results);
                                }
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                    }
                }
                while (result.info.Next != null);

                AfterDataLoad?.Invoke(this, new EventArgs()); 
                return characters;
            }
        }
    }
}
