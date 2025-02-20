using OTLOB_7aln_Core.Entities;
using OTLOB_7aln_Core.Specification;

namespace OTLOB_7aln_Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public  Task<IEnumerable<T>> GetAllWithSpecsAsync(ISpecification<T> specs);
        public Task<T> GetByIdWithSpecsAsync(ISpecification<T>specs);
        public Task<int> GetCountAsync(ISpecification<T> specs);
        public Task CreateAsync(T entity);
        public void Delete(T entity);
        public void Update(T entity);

    }
}
