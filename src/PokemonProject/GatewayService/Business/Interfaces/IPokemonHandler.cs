using Common.Db.Dto;

namespace GatewayService.Business.Interfaces
{
    public interface IPokemonHandler
    {
        public Task<PokemonDtoList> GetAllPokemon(CancellationToken cancellationToken);
        public Task<PokemonDtoList> GetPokemonRange(int from, int to, CancellationToken cancellationToken);
        public Task<PokemonDto> GetPokemon(int id, CancellationToken cancellationToken);
        public Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task DeletePokemons(ICollection<int> ids, CancellationToken cancellationToken);
    }
}
