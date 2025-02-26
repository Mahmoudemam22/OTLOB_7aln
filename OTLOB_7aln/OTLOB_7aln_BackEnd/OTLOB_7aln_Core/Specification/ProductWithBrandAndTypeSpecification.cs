﻿using OTLOB_7aln_Core.Entities;

namespace OTLOB_7aln_Core.Specification
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypeSpecification(ProductsSpecParams productsSpecParams) :base(p=>
            (string.IsNullOrEmpty(productsSpecParams.search) ||p.Name.ToLower().Contains(productsSpecParams.search.ToLower()))&&
            (!productsSpecParams.BrandId.HasValue || productsSpecParams.BrandId == p.ProductBrandId) &&
            (!productsSpecParams.TypeId.HasValue || productsSpecParams.TypeId==p.ProductTypeId)
            )
        {
            this.Includes.Add(p => p.ProductBrand);
            this.Includes.Add(p => p.ProductType);
            int skip = productsSpecParams.PageSize * (productsSpecParams.PageIndex - 1);
            int take = productsSpecParams.PageSize;
            this.ApplyPagination(skip, take);
            if (!string.IsNullOrEmpty(productsSpecParams.sort))
            {
                switch (productsSpecParams.sort)
                {
                    case "priceAsc":
                        this.AddOrderByAscending(p => p.Price);
                        break;
                    case "priceDesc":
                        this.AddOrderByDescending(p => p.Price);
                        break;
                    case "name":
                        this.AddOrderByAscending(p => p.Name);
                        break;
                    case "nameDesc":
                        this.AddOrderByDescending(p => p.Name);
                        break;
                    default:
                        this.AddOrderByAscending(p => p.Name);
                        break;
                }
            }
        }
        public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
        {
            this.Includes.Add(p => p.ProductBrand);
            this.Includes.Add(p => p.ProductType);
        }

    }
}