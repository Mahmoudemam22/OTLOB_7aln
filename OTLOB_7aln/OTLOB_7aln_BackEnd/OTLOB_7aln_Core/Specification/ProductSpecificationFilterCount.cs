using OTLOB_7aln_Core.Entities;

namespace OTLOB_7aln_Core.Specification
{
    public class ProductSpecificationFilterCount : BaseSpecification<Product>
    {
        public ProductSpecificationFilterCount(ProductsSpecParams productsSpecParams) :base(p=>
            
            (string.IsNullOrEmpty(productsSpecParams.search) ||p.Name.ToLower().Contains(productsSpecParams.search.ToLower()))&&
            (!productsSpecParams.BrandId.HasValue || productsSpecParams.BrandId == p.ProductBrandId) &&
            (!productsSpecParams.TypeId.HasValue || productsSpecParams.TypeId==p.ProductTypeId)
            )
        {
        }
    }
}
