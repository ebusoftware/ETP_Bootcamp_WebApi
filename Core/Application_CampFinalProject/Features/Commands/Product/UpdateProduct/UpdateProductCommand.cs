using Application_CampFinalProject.Dtos.Product;
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
    public class UpdateProductCommand:IRequest<UpdateProductDTO>
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductDTO>
        {
            private readonly IMapper _mapper;
            private readonly IProductWriteRepository _productWriteRepository;

            public UpdateProductCommandHandler(IMapper mapper, IProductWriteRepository productWriteRepository)
            {
                _mapper = mapper;
                _productWriteRepository = productWriteRepository;
            }

            public async Task<UpdateProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product mappedProduct = _mapper.Map<Product>(request);
                Product updatedProduct = await _productWriteRepository.UpdateAsync(mappedProduct);
                UpdateProductDTO updateProductDTO = _mapper.Map<UpdateProductDTO>(updatedProduct);
                return updateProductDTO;
            }
        }
    }
}
