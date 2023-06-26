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

        public async Task<ICollection<Pokemon>> GetAllPokemon(CancellationToken cancellationToken)
        {
            return await _dbContext.Pokemons
                .Include(x => x.Translations)
                .Include(x => x.PokemonTypes)
                .Include(x => x.Stats)
                .ToListAsync(cancellationToken);
        }

        public async Task<Pokemon> GetPokemon(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Pokemons
                .Include(x => x.Translations)
                .Include(x => x.PokemonTypes)
                .Include(x => x.Stats)
                .Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ICollection<Pokemon>> GetPokemonRange(int from, int to, CancellationToken cancellationToken)
        {
            return await _dbContext.Pokemons
                .Include(x => x.Translations)
                .Include(x => x.PokemonTypes)
                .Include(x => x.Stats)
                .Where(x => x.Id >= from && x.Id <= to).ToListAsync(cancellationToken);
        }
    }
}
