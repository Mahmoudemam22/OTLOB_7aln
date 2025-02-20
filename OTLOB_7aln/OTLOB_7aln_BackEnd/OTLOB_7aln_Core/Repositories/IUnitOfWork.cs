using OTLOB_7aln_Core.Entities;

namespace OTLOB_7aln_Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<T> Repository<T>() where T : BaseEntity;
        public Task<int> Complete();
    }
}
