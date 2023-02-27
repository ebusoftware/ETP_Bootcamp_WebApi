using Application_CampFinalProject.Dtos.Brand;
using Application_CampFinalProject.Repositories;
using AutoMapper;
using Domain_CampFinalProject.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features
{
    public class GetAllBrandQuery: IRequest<List<GetAllBrandDTO>>
    {
        public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, List<GetAllBrandDTO>>
        {
            private readonly IMapper _mapper;
            private readonly IBrandReadRepository _brandReadRepository;

            public GetAllBrandQueryHandler(IMapper mapper, IBrandReadRepository brandReadRepository)
            {
                _mapper = mapper;
                _brandReadRepository = brandReadRepository;
            }

            public async Task<List<GetAllBrandDTO>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
            {
                List<Brand> brands = await _brandReadRepository.GetAllAsync();
                return brands.Select(e=> new GetAllBrandDTO 
                {
                    Id = e.Id,
                    BrandName= e.BrandName,
                }).ToList();
                

            }
        }
    }
}
