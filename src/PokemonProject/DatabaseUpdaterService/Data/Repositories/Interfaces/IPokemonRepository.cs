using Common.Db.Dto;
using Communications.Dto;

namespace DatabaseUpdaterService.Data.Repositories.Interfaces
{
    public interface IPokemonRepository
    {
        void AddPokemon(PokemonDto pokemon);
        Task UpdatePokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        Task DeletePokemons(IdList ids, CancellationToken cancellationToken);
    }
}
