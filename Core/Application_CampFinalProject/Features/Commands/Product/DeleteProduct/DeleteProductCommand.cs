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
    public class DeleteProductCommand:IRequest<DeleteProductDTO>
    {
        public int Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductDTO>
        {
            private readonly IMapper _mapper;
            private readonly IProductWriteRepository _productWriteRepository;

            public DeleteProductCommandHandler(IMapper mapper, IProductWriteRepository productWriteRepository)
            {
                _mapper = mapper;
                _productWriteRepository = productWriteRepository;
            }

            public async Task<DeleteProductDTO> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                Product mappedProduct = _mapper.Map<Product>(request);
                Product deletedProduct= await _productWriteRepository.RemoveAsync(mappedProduct);
                DeleteProductDTO deleteProductDTO = _mapper.Map<DeleteProductDTO>(deletedProduct);
                return deleteProductDTO;
            }
        }
    }
}
