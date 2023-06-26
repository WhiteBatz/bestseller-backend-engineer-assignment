using Common.Db.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communications.ServiceContracts
{
    public interface ITranslationService
    {
        public Task<TranslationDtoList> GetTranslationsForPokemon(int id, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetTranslationsForPokemonRange(int from, int to, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetLocaleTranslationForPokemon(string locale, int id, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetLocaleTranslationForPokemonRange(string locale, int from, int to, CancellationToken cancellationToken);
    }
}
