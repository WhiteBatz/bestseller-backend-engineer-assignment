using Common.Db.Dto;

namespace GatewayService.Business.Interfaces
{
    public interface ITranslationHandler
    {
        public Task<TranslationDtoList> GetTranslationsForPokemon(int id, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetTranslationsForPokemonRange(int from, int to, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetLocaleTranslationForPokemon(string locale, int id, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetLocaleTranslationForPokemonRange(string locale, int from, int to, CancellationToken cancellationToken);
    }
}
