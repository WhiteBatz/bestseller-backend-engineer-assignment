using Common.Db.Dto;
using Communications.Dto;
using Communications.ServiceContracts;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communications.Services
{
    public class PokemonService : IPokemonService
    {
        private string _baseUrl = "http://pokemonservice/api/Pokemon/";

        public async Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            try
            {
                await $"{_baseUrl}AddPokemon".PutJsonAsync(pokemon, cancellationToken);
            }
            catch (Exception ex)
            {
                //Should Log Error
                var i = 2 + 2;
                throw;
            }
        }

        public async Task DeletePokemons(IdList ids, CancellationToken cancellationToken)
        {
            try
            {
                await $"{_baseUrl}DeletePokemons".PostJsonAsync(ids, cancellationToken);
            }
            catch (Exception ex)
            {
                //Should Log Error
                var i = 2 + 2;
                throw;
            }
        }

        public async Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            try
            {
                await $"{_baseUrl}EditPokemon".PostJsonAsync(pokemon, cancellationToken);
            }
            catch (Exception ex)
            {
                //Should Log Error
                var i = 2 + 2;
                throw;
            }
        }

        public async Task<PokemonDtoList> GetAllPokemon(CancellationToken cancellationToken)
        {
            try
            {
                var result = await $"{_baseUrl}GetAllPokemon".GetJsonAsync<PokemonDtoList>(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                //Should Log Error
                var i = 2 + 2;
                throw;
            }
        }

        public async Task<PokemonDto> GetPokemon(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await $"{_baseUrl}GetPokemon?id={id}".GetJsonAsync<PokemonDto>(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                //Should Log Error
                var i = 2 + 2;
                throw;
            }
        }

        public async Task<PokemonDtoList> GetPokemonRange(int from, int to, CancellationToken cancellationToken)
        {
            try
            {
                var result = await $"{_baseUrl}GetPokemonRange?from={from}&to={to}".GetJsonAsync<PokemonDtoList>(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                //Should Log Error
                var i = 2 + 2;
                throw;
            }
        }
    }
}
