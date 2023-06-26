using Common.Db.Dto;

namespace DatabaseUpdaterService.Data.Repositories.Interfaces
{
    public interface ITranslationRepository
    {
        public Task<TranslationDtoList> GetTranslationsForPokemon(int id, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetTranslationsForPokemonRange(int from, int to, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetLocaleTranslationForPokemon(string locale, int id, CancellationToken cancellationToken);
        public Task<TranslationDtoList> GetLocaleTranslationForPokemonRange(string locale, int from, int to, CancellationToken cancellationToken);
    }
}
