using Common.Db.Dto;
using Communications.Dto;

namespace PokemonService.Business.Interfaces
{
    public interface IPokemonHandler
    {
        public Task<PokemonDtoList> GetAllPokemon(CancellationToken cancellationToken);
        public Task<PokemonDtoList> GetPokemonRange(int from, int to, CancellationToken cancellationToken);
        public Task<PokemonDto> GetPokemon(int id, CancellationToken cancellationToken);
        public Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task DeletePokemons(IdList ids, CancellationToken cancellationToken);
    }
}
