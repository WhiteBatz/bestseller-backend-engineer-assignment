using Common.Db.Data.Models;
using Common.Db.Dto;
using Communications.Dto;

namespace DatabaseUpdaterService.Data.Repositories.Interfaces
{
    public interface IPokemonRepository
    {
        Task<ICollection<Pokemon>> GetAllPokemon(CancellationToken cancellationToken);
        Task<Pokemon> GetPokemon(int id, CancellationToken cancellationToken);
        Task<ICollection<Pokemon>> GetPokemonRange(int from, int to, CancellationToken cancellationToken);
    }
}
