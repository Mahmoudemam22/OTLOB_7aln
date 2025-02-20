using Microsoft.EntityFrameworkCore;
using OTLOB_7aln_Core.Entities;
using OTLOB_7aln_Core.Specification;

namespace OTLOB_7aln_Repository.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> BuildQuery(IQueryable<T> EntryPoint, ISpecification<T> Specs)
        {
            var query = EntryPoint;
            if (Specs.Criteria != null)
            {
                query = query.Where(Specs.Criteria);
            }
            if (Specs.IsPaginationEnabled==true)
            {
                query = query.Skip(Specs.skip).Take(Specs.take);
            }
            if (Specs.OrderByDescending != null)
            {
                query=query.OrderByDescending(Specs.OrderByDescending);
            }
            if (Specs.OrderByAscending != null)
            {
                query = query.OrderBy(Specs.OrderByAscending);
            }
            query = Specs.Includes.Aggregate(query, (currquery, specsInclude) => currquery.Include(specsInclude));
            return query;
        }
    }
}
