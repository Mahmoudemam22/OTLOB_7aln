using OTLOB_7aln_Core.Entities;
using System.Linq.Expressions;

namespace OTLOB_7aln_Core.Specification;
public interface ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; }
    public Expression<Func<T, object>> OrderByAscending { get; set; }
    public Expression<Func<T, object>> OrderByDescending { get; set; }
    public int skip { get; set; }
    public int take { get; set; }
    public bool IsPaginationEnabled { get; set; }

    public void AddOrderByAscending(Expression<Func<T, object>> sort);
    public void AddOrderByDescending(Expression<Func<T, object>> sort);
    public void ApplyPagination(int skip, int take);


}
