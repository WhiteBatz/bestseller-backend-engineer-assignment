using Common.Db.Data;
using Common.Db.Data.Models;
using Common.Db.Dto;
using DatabaseUpdaterService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseUpdaterService.Data.Repositories
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly PokemonContext _dbContext;

        public TranslationRepository(PokemonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TranslationDtoList> GetLocaleTranslationForPokemon(string locale, int id, CancellationToken cancellationToken)
        {
            var translations = await _dbContext.Translations.Where(x => x.PokemonId == id && x.TranslationCode.Equals(locale))
                .Select(x => new TranslationDto
            {
                Name = x.Name,
                PokemonId = x.PokemonId,
                TranslationCode = x.TranslationCode,
            }).ToListAsync(cancellationToken);

            if (translations == null || translations.Count == 0)
                return null;

            return new TranslationDtoList
            {
                Translations = translations
            };
        }

        public async Task<TranslationDtoList> GetLocaleTranslationForPokemonRange(string locale, int from, int to, CancellationToken cancellationToken)
        {
            var translations = await _dbContext.Translations.Where(x => x.PokemonId >= from && 
            x.PokemonId <= to && 
            x.TranslationCode.Equals(locale)).Select(x => new TranslationDto
            {
                Name = x.Name,
                PokemonId = x.PokemonId,
                TranslationCode = x.TranslationCode,
            }).ToListAsync(cancellationToken);

            if (translations == null || translations.Count == 0)
                return null;

            return new TranslationDtoList
            {
                Translations = translations
            };
        }

        public async Task<TranslationDtoList> GetTranslationsForPokemon(int id, CancellationToken cancellationToken)
        {
            var translations = await _dbContext.Translations.Where(x => x.PokemonId == id)
                .Select(x => new TranslationDto
                {
                    Name = x.Name,
                    PokemonId = x.PokemonId,
                    TranslationCode = x.TranslationCode,
                }).ToListAsync(cancellationToken);

            if (translations == null || translations.Count == 0)
                return null;

            return new TranslationDtoList
            {
                Translations = translations
            };
        }

        public async Task<TranslationDtoList> GetTranslationsForPokemonRange(int from, int to, CancellationToken cancellationToken)
        {
            var translations = await _dbContext.Translations.Where(x => x.PokemonId >= from &&
            x.PokemonId <= to).Select(x => new TranslationDto
            {
                Name = x.Name,
                PokemonId = x.PokemonId,
                TranslationCode = x.TranslationCode,
            }).ToListAsync(cancellationToken);

            if (translations == null || translations.Count == 0)
                return null;

            return new TranslationDtoList
            {
                Translations = translations
            };
        }
    }
}
