using Common.Db.Dto;
using Communications.Dto;
using Communications.ServiceContracts;
using Flurl.Http;
using GatewayService.Business.Interfaces;
using Newtonsoft.Json;

namespace GatewayService.Business
{
    public class PokemonHandler : IPokemonHandler
    {
        private readonly IPokemonService _pokemonService;

        public PokemonHandler(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            await _pokemonService.AddPokemon(pokemon, cancellationToken);
        }

        public async Task DeletePokemons(ICollection<int> ids, CancellationToken cancellationToken)
        {
            var idList = new IdList(ids);
            await _pokemonService.DeletePokemons(idList, cancellationToken);
        }

        public async Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            await _pokemonService.EditPokemon(pokemon, cancellationToken);  
        }

        public async Task<PokemonDtoList> GetAllPokemon(CancellationToken cancellationToken)
        {
            return await _pokemonService.GetAllPokemon(cancellationToken);
        }

        public async Task<PokemonDto> GetPokemon(int id, CancellationToken cancellationToken)
        {
            return await _pokemonService.GetPokemon(id, cancellationToken); 
        }

        public async Task<PokemonDtoList> GetPokemonRange(int from, int to, CancellationToken cancellationToken)
        {
            return await _pokemonService.GetPokemonRange(from, to, cancellationToken);
        }
    }
}
