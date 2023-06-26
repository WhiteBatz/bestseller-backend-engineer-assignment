using Communications.ServiceContracts;
using Communications.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communications.Extensions
{
    public static class CommunicationDependenciesExtensions
    {
        public static void AddCommunicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<ITranslationService, TranslationService>();
            services.AddScoped<IDatabaseUpdaterService, DatabaseUpdaterService>();
        }
    }
}
