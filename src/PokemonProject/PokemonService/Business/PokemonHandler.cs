using Common.Db.Data.Models;
using Common.Db.Dto;
using Communications.Dto;
using Communications.ServiceContracts;
using DatabaseUpdaterService.Data;
using PokemonService.Business.Interfaces;

namespace PokemonService.Business
{
    public class PokemonHandler : IPokemonHandler
    {
        private readonly IDatabaseUpdaterService _dbUpdaterService;
        private readonly IUnitOfWork _unitOfWork;

        public PokemonHandler(IDatabaseUpdaterService dbUpdaterService, IUnitOfWork unitOfWork)
        {
            _dbUpdaterService = dbUpdaterService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddPokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            await _dbUpdaterService.AddPokemon(pokemon, cancellationToken);
        }

        public async Task DeletePokemons(IdList ids, CancellationToken cancellationToken)
        {
            await _dbUpdaterService.DeletePokemons(ids, cancellationToken);
        }

        public async Task EditPokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            await _dbUpdaterService.EditPokemon(pokemon, cancellationToken);
        }

        public async Task<PokemonDtoList> GetAllPokemon(CancellationToken cancellationToken)
        {
            var models = await _unitOfWork.PokemonRepository.GetAllPokemon(cancellationToken);

            if (models == null || models.Count == 0)
                return null;

            return new PokemonDtoList
            {
                Pokemons = models.Select(GetDtoFromModel).ToList()
            };
        }

        public async Task<PokemonDto> GetPokemon(int id, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.PokemonRepository.GetPokemon(id, cancellationToken);

            return GetDtoFromModel(model);
        }

        public async Task<PokemonDtoList> GetPokemonRange(int from, int to, CancellationToken cancellationToken)
        {
            var models = await _unitOfWork.PokemonRepository.GetPokemonRange(from, to, cancellationToken);

            if (models == null || models.Count == 0)
                return null;

            return new PokemonDtoList
            {
                Pokemons = models.Select(GetDtoFromModel).ToList()
            };
        }

        private PokemonDto GetDtoFromModel(Pokemon pokemon)
        {
            if (pokemon == null)
                return null;

            return new PokemonDto
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                PokemonTypes = pokemon.PokemonTypes.Select(x => new PokemonTypeDto
                {
                    TypeName = x.TypeName
                }).ToList(),
                Stats = new BaseStatDto
                {
                    Attack = pokemon.Stats.Attack,
                    SpAttack = pokemon.Stats.SpAttack,
                    Defense = pokemon.Stats.Defense,
                    Hp = pokemon.Stats.Hp,
                    PokemonId = pokemon.Id,
                    SpDefense = pokemon.Stats.SpDefense,
                    Speed = pokemon.Stats.Speed,
                },
                Translations = pokemon.Translations.Select(x => new TranslationDto
                {
                    Name = x.Name,
                    PokemonId = pokemon.Id,
                    TranslationCode = x.TranslationCode,
                }).ToList(),
            };
        }
    }
}
