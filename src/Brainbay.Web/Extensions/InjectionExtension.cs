using Brainbay.Business;
using Brainbay.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainbay.Web.Extensions
{
    public static class InjectionExtension
    {
        public static void ComfigureInjections(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DbContext, CharacterDbContext>();
            serviceCollection.AddScoped<ICharacterRepository, CharacterRepository>();
            serviceCollection.AddScoped<ICharacterTypeRepository, CharacterTypeRepository>();
            serviceCollection.AddScoped<IEpisodeRepository, EpisodeRepository>();
            serviceCollection.AddScoped<IGenderRepository, GenderRepository>();
            serviceCollection.AddScoped<ILocationRepository, LocationRepository>();
            serviceCollection.AddScoped<IOriginRepository, OriginRepository>();
            serviceCollection.AddScoped<ISpeciesRepository, SpeciesRepository>();
            serviceCollection.AddScoped<IStatusRepository, StatusRepository>();

            serviceCollection.AddScoped<ICharacterBusiness, CharacterBusiness>();
            serviceCollection.AddScoped<ICharacterTypeBusiness, CharacterTypeBusiness>();
            serviceCollection.AddScoped<IEpisodeBusiness, EpisodeBusiness>();
            serviceCollection.AddScoped<IGenderBusiness, GenderBusiness>();
            serviceCollection.AddScoped<ILocationBusiness, LocationBusiness>();
            serviceCollection.AddScoped<IOriginBusiness, OriginBusiness>();
            serviceCollection.AddScoped<ISpeciesBusiness, SpeciesBusiness>();
            serviceCollection.AddScoped<IStatusBusiness, StatusBusiness>();

        }
    }
}
