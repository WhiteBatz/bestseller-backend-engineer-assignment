using Common.Db.Dto;
using DatabaseUpdaterService.Data;
using TranslationService.Business.Interfaces;

namespace TranslationService.Business
{
    public class TranslationHandler : ITranslationHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public TranslationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TranslationDtoList> GetLocaleTranslationForPokemon(string locale, int id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TranslationRepository.GetLocaleTranslationForPokemon(locale, id, cancellationToken);
        }

        public async Task<TranslationDtoList> GetLocaleTranslationForPokemonRange(string locale, int from, int to, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TranslationRepository.GetLocaleTranslationForPokemonRange(locale, from, to, cancellationToken);
        }

        public async Task<TranslationDtoList> GetTranslationsForPokemon(int id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TranslationRepository.GetTranslationsForPokemon(id, cancellationToken);
        }

        public async Task<TranslationDtoList> GetTranslationsForPokemonRange(int from, int to, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TranslationRepository.GetTranslationsForPokemonRange(from, to, cancellationToken);
        }
    }
}
