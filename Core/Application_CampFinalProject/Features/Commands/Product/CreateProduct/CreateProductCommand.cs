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
    public class CreateProductCommand : IRequest<CreateProductDTO>
    {
        //Request
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDTO>
        {
            private readonly IMapper _mapper;
            private readonly IProductWriteRepository _productWriteRepository;

            public CreateProductCommandHandler(IMapper mapper, IProductWriteRepository productWriteRepository)
            {
                _mapper = mapper;
                _productWriteRepository = productWriteRepository;
            }

            public async Task<CreateProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product mappedProduct = _mapper.Map<Product>(request);
                Product createdProduct = await _productWriteRepository.AddAsync(mappedProduct);
                CreateProductDTO createProductDTO = _mapper.Map<CreateProductDTO>(createdProduct);
                return createProductDTO;
            }
        }
    }
}
