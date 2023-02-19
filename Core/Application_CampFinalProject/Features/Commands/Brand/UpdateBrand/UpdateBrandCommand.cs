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
    public class UpdateBrandCommand : IRequest<UpdateBrandDTO>
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandDTO>
        {
            IMapper _mapper;
            IBrandWriteRepository _brandWriteRepository;

            public UpdateBrandCommandHandler(IMapper mapper, IBrandWriteRepository brandWriteRepository)
            {
                _mapper = mapper;
                _brandWriteRepository = brandWriteRepository;
            }

            public async Task<UpdateBrandDTO> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand updatedBrand = await _brandWriteRepository.UpdateAsync(mappedBrand);
                UpdateBrandDTO updateBrandDTO = _mapper.Map<UpdateBrandDTO>(updatedBrand);
                return updateBrandDTO;
            }
        }
    }
}
