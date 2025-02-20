using OTLOB_7aln_Core.Entities;
using OTLOB_7aln_Core.Repositories;
using OTLOB_7aln_Repository;
using OTLOB_7aln_Repository.Data;
using System.Collections;

namespace OTLOB_7aln_Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable repositories { get; set; }
        public StoreContext StoreContext { get; }

        public UnitOfWork(StoreContext StoreContext)
        {
            this.StoreContext = StoreContext;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (repositories == null)
                repositories = new Hashtable();
            var type = typeof(T);
            if (!repositories.ContainsKey(type))
                repositories.Add(type, new GenericRepository<T>(StoreContext));
            return (IGenericRepository<T>)repositories[type];
        }

        public async Task<int> Complete()
        {
            return await this.StoreContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await this.StoreContext.DisposeAsync();
        }
    }
}
