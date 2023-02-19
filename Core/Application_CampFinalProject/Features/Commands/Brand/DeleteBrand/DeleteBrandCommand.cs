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
    public class DeleteBrandCommand:IRequest<DeleteBrandDTO>
    {
        public int Id { get; set; }
        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandDTO>
        {
            private readonly IMapper _mapper;
            private readonly IBrandWriteRepository _brandWriteRepository;

            public DeleteBrandCommandHandler(IMapper mapper, IBrandWriteRepository brandWriteRepository)
            {
                _mapper = mapper;
                _brandWriteRepository = brandWriteRepository;
            }

            public async Task<DeleteBrandDTO> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand deletedBrand = await _brandWriteRepository.RemoveAsync(mappedBrand);
                DeleteBrandDTO deleteBrandDTO = _mapper.Map<DeleteBrandDTO>(deletedBrand);
                return deleteBrandDTO;

            }
        }
    }
}
