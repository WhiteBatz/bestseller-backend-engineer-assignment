using Common.Db.Dto;
using Communications.Dto;
using DatabaseUpdaterService.Business.Interfaces;
using DatabaseUpdaterService.Data;

namespace DatabaseUpdaterService.Business
{
    public class PokemonHandler : IPokemonHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public PokemonHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            _unitOfWork.PokemonRepository.AddPokemon(pokemon);

            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task DeletePokemons(IdList ids, CancellationToken cancellationToken)
        {
            await _unitOfWork.PokemonRepository.DeletePokemons(ids, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            await _unitOfWork.PokemonRepository.UpdatePokemon(pokemon, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
