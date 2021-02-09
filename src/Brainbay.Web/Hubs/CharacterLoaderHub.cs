using Brainbay.Business;
using Brainbay.Common.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brainbay.Web.Hubs
{
    public class CharacterLoaderHub : Hub
    {
        private ICharacterBusiness _characterBusiness;
        IEnumerable<Character> characters;
        private bool disconnected = false;
        public CharacterLoaderHub(ICharacterBusiness characterBusiness)
        {
            _characterBusiness = characterBusiness; 
        }

        public async Task Start()
        {
            do
            {
                try
                {
                    await Clients.All.SendAsync("loginfo", "trying to get characters...");

                    var result = await _characterBusiness.GetAllCharactersAsync();

                    if (characters != null)
                    {
                        if (characters.Count() != result.Result.Count())
                        {
                            characters = result.Result;
                            await Clients.All.SendAsync("UpdateView", new { Result = result.Result, Time = DateTime.Now });
                        }
                        else
                        {
                            await Clients.All.SendAsync("updatetime", new { time = DateTime.Now });
                        }
                    }
                    else
                    {
                        characters = result.Result;
                        await Clients.All.SendAsync("UpdateView", new { Result = result.Result, Time = DateTime.Now });
                    }
                }
                catch(Exception exp)
                {
                    await Clients.All.SendAsync("logerr", exp.Message);
                }

                Thread.Sleep(10000);
            } while (!disconnected);
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            disconnected = true;
            return base.OnDisconnectedAsync(exception);
        }
    }
}
