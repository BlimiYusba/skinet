using API.Dtos;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(p=>p.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(p => p.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(p=>p.PictureUrl,o=>o.MapFrom<ResolveUrl>());
        }
    }
}
