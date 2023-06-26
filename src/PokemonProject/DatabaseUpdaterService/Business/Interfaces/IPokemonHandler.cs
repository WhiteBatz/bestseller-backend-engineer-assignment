using Common.Db.Dto;
using Communications.Dto;

namespace DatabaseUpdaterService.Business.Interfaces
{
    public interface IPokemonHandler
    {
        public Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task DeletePokemons(IdList ids, CancellationToken cancellationToken);
    }
}
