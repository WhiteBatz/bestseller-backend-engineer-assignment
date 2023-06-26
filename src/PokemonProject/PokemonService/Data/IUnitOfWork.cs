using DatabaseUpdaterService.Data.Repositories.Interfaces;

namespace DatabaseUpdaterService.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPokemonRepository PokemonRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
