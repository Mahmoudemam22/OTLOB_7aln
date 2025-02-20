using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OTLOB_7aln_API.Dtos;
using OTLOB_7aln_API.Helpers;
using OTLOB_7aln_Core.Entities;
using OTLOB_7aln_Core.Repositories;
using OTLOB_7aln_Core.Specification;

namespace OTLOB_7aln_API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        public IMapper _mapper { get; }
        public IUnitOfWork _unitOfWork { get; }

        public ProductsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] ProductsSpecParams productsSpecParams)
        {
            var specs = new ProductWithBrandAndTypeSpecification(productsSpecParams);
            var products = await this._unitOfWork.Repository<Product>().GetAllWithSpecsAsync(specs);
            var data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            var countSpecs = new ProductSpecificationFilterCount(productsSpecParams);
            var count = await this._unitOfWork.Repository<Product>().GetCountAsync(countSpecs);
            var PaginatedData = new Pagination<ProductDto>(data, productsSpecParams.PageSize, productsSpecParams.PageIndex, count);
            return Ok(PaginatedData);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var specs = new ProductWithBrandAndTypeSpecification(id);
            var product = await this._unitOfWork.Repository<Product>().GetByIdWithSpecsAsync(specs);

            return new OkObjectResult(_mapper.Map<Product, ProductDto>(product));
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
        {
            var ProductBrands = await this._unitOfWork.Repository<ProductBrand>().GetAllAsync();
            return new OkObjectResult(ProductBrands);
        }
    }
}