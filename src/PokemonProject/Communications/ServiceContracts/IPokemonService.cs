using Common.Db.Dto;
using Communications.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communications.ServiceContracts
{
    public interface IPokemonService
    {
        public Task<PokemonDtoList> GetAllPokemon(CancellationToken cancellationToken);
        public Task<PokemonDtoList> GetPokemonRange(int from, int to, CancellationToken cancellationToken);
        public Task<PokemonDto> GetPokemon(int id, CancellationToken cancellationToken);
        public Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken);   
        public Task DeletePokemons(IdList ids, CancellationToken cancellationToken);
    }
}
