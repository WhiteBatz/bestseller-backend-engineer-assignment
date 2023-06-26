using Common.Db.Dto;
using Communications.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communications.ServiceContracts
{
    public interface IDatabaseUpdaterService
    {
        public Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken);
        public Task DeletePokemons(IdList ids, CancellationToken cancellationToken);
    }
}
