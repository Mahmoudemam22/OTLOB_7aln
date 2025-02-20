using AutoMapper;
using OTLOB_7aln_API.Dtos;
using OTLOB_7aln_Core.Entities;
namespace OTLOB_7aln_API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.ProductBrand, o => o.MapFrom(c => c.ProductBrand.Name));

            CreateMap<OTLOB_7aln_Core.Entities.Identity.Address, AddressDto>().ReverseMap();
    
        }
    }
}
