using Common.Db.Data;
using Common.Db.Data.Models;
using Common.Db.Dto;
using Communications.Dto;
using DatabaseUpdaterService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseUpdaterService.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _dbContext;

        public PokemonRepository(PokemonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPokemon(PokemonDto pokemon)
        {
            var model = new Pokemon
            {
                Name = pokemon.Name,
                PokemonTypes = pokemon.PokemonTypes.Select(x => new PokemonType
                {
                    TypeName = x.TypeName
                }).ToList(),
                Stats = new BaseStat
                {
                    Attack = pokemon.Stats.Attack,
                    SpAttack = pokemon.Stats.SpAttack,
                    Defense = pokemon.Stats.Defense,
                    Hp = pokemon.Stats.Hp,
                    SpDefense = pokemon.Stats.SpDefense,
                    Speed = pokemon.Stats.Speed,
                },
                Translations = pokemon.Translations.Select(x => new Translation { Name = x.Name, TranslationCode = x.TranslationCode }).ToList(),
            };

            _dbContext.Add(model);
        }

        public async Task DeletePokemons(IdList ids, CancellationToken cancellationToken)
        {
            var pokemons = await _dbContext.Pokemons.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);

            _dbContext.Pokemons.RemoveRange(pokemons);
        }

        public async Task UpdatePokemon(PokemonDto pokemon, CancellationToken cancellationToken)
        {
            var model = await _dbContext.Pokemons
                .Include(x => x.Stats)
                .Include(x => x.Translations)
                .Include(x => x.PokemonTypes)
                .Where(x => x.Id == pokemon.Id).FirstOrDefaultAsync(cancellationToken);

            if (model == null)
                return;

            model.Name = pokemon.Name;
            model.PokemonTypes = pokemon.PokemonTypes.Select(x => new PokemonType
            {
                PokemonId = model.Id,
                TypeName = x.TypeName
            }).ToList();
            model.Stats.Attack = pokemon.Stats.Attack;
            model.Stats.SpAttack = pokemon.Stats.SpAttack;
            model.Stats.Defense = pokemon.Stats.Defense;
            model.Stats.Hp = pokemon.Stats.Hp;
            model.Stats.SpDefense = pokemon.Stats.SpDefense;
            model.Stats.Speed = pokemon.Stats.Speed;

            model.Translations = pokemon.Translations.Select(x => new Translation { Name = x.Name, TranslationCode = x.TranslationCode }).ToList();

            _dbContext.Pokemons.Update(model);
        }
    }
}
