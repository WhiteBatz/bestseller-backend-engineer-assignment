using Common.Db.Dto;
using Communications.ServiceContracts;
using GatewayService.Business.Interfaces;

namespace GatewayService.Business
{
    public class TranslationHandler : ITranslationHandler
    {
        private readonly ITranslationService _translationService;

        public TranslationHandler(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public async Task<TranslationDtoList> GetLocaleTranslationForPokemon(string locale, int id, CancellationToken cancellationToken)
        {
            return await _translationService.GetLocaleTranslationForPokemon(locale, id, cancellationToken);
        }

        public async Task<TranslationDtoList> GetLocaleTranslationForPokemonRange(string locale, int from, int to, CancellationToken cancellationToken)
        {
            return await _translationService.GetLocaleTranslationForPokemonRange(locale, from, to, cancellationToken);
        }

        public async Task<TranslationDtoList> GetTranslationsForPokemon(int id, CancellationToken cancellationToken)
        {
            return await _translationService.GetTranslationsForPokemon(id, cancellationToken);
        }

        public async Task<TranslationDtoList> GetTranslationsForPokemonRange(int from, int to, CancellationToken cancellationToken)
        {
            return await _translationService.GetTranslationsForPokemonRange(from, to, cancellationToken);
        }
    }
}
