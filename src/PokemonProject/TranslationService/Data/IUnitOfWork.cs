using DatabaseUpdaterService.Data.Repositories.Interfaces;

namespace DatabaseUpdaterService.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ITranslationRepository TranslationRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
