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

namespace Application_CampFinalProject.Features.Commands
{
    public class CreateBrandCommand:IRequest<CreateBrandDTO>
    {
        //Bu sinifta Requestleri tanımladım. Başka bi class olusturup, requestleri de tanimlayabilirdik. Fakat aşırı tasarima kacmamak icin bu yolu tercih ettim.
        public string BrandName { get; set; }

        //CreatedBrandCommandHandler = Bu sınıfta, Ele alacağımız islemleri yapıyoruz. Ben asenkron calısacagım.
        public class CreatedBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandDTO>
        {
            private readonly IMapper _mapper;
            private readonly IBrandWriteRepository _brandWriteRepository;

            public CreatedBrandCommandHandler(IMapper mapper, IBrandWriteRepository brandWriteRepository)
            {
                _mapper = mapper;
                _brandWriteRepository = brandWriteRepository;
            }

            public async Task<CreateBrandDTO> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand createdBrand = await _brandWriteRepository.AddAsync(mappedBrand);
                CreateBrandDTO createBrandDTO = _mapper.Map<CreateBrandDTO>(createdBrand);
                return createBrandDTO;
                
            }
        }

    }
}
