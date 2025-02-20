using Microsoft.EntityFrameworkCore;
using OTLOB_7aln_Core.Entities;
using OTLOB_7aln_Core.Repositories;
using OTLOB_7aln_Core.Specification;
using OTLOB_7aln_Repository.Data;

namespace OTLOB_7aln_Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public StoreContext StoreContext { get; }
        public GenericRepository(StoreContext StoreContext)
        {
            this.StoreContext = StoreContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.StoreContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await this.StoreContext.Set<T>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> GetAllWithSpecsAsync(ISpecification<T> specs)
        {
            return await this.ApplyQuery(specs).ToListAsync();
        }
        public async Task<T> GetByIdWithSpecsAsync(ISpecification<T> specs)
        {
            return await this.ApplyQuery(specs).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplyQuery(ISpecification<T>specs)
        {
            return SpecificationEvaluator<T>.BuildQuery(this.StoreContext.Set<T>(), specs);
        }

        public async Task<int> GetCountAsync(ISpecification<T> specs)
        {
            return await SpecificationEvaluator<T>.BuildQuery(this.StoreContext.Set<T>(), specs).CountAsync();
        }

        public async Task CreateAsync(T entity)
        {
             await this.StoreContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
              this.StoreContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            this.StoreContext.Set<T>().Update(entity);
        }
    }
}
