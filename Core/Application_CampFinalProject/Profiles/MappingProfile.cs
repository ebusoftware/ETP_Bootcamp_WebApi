using Application_CampFinalProject.Dtos.Brand;
using Application_CampFinalProject.Features.Commands;
using AutoMapper;
using Domain_CampFinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //Brand
            CreateMap<Brand,CreateBrandDTO>().ReverseMap();
            CreateMap<Brand,CreateBrandCommand>().ReverseMap();

            CreateMap<Brand,DeleteBrandDTO>().ReverseMap();
            CreateMap<Brand,DeleteBrandCommand>().ReverseMap();

            CreateMap<Brand,UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand,UpdateBrandDTO>().ReverseMap();


        }
    }
}
