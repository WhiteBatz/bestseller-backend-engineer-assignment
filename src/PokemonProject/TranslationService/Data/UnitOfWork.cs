using Common.Db.Data;
using DatabaseUpdaterService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseUpdaterService.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PokemonContext _dbContext;
        private bool _disposed;

        public UnitOfWork(PokemonContext databaseContext, ITranslationRepository translationRepository)
        {
            _dbContext = databaseContext;
            TranslationRepository = translationRepository;
        }

        public ITranslationRepository TranslationRepository { get; }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
