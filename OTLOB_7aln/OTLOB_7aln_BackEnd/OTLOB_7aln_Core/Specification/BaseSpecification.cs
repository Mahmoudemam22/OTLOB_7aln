using OTLOB_7aln_Core.Entities;
using System.Linq.Expressions;

namespace OTLOB_7aln_Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderByAscending { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public bool IsPaginationEnabled { get; set; }=false;

        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }
        public void AddOrderByAscending(Expression<Func<T, object>> sort)
        {
            this.OrderByAscending = sort;
        }
        public void AddOrderByDescending(Expression<Func<T, object>> sort)
        {
            this.OrderByDescending = sort;
        }

        public void ApplyPagination(int skip, int take)
        {
            this.IsPaginationEnabled = true;
            this.take = take;
            this.skip = skip;
        }
    }
}
