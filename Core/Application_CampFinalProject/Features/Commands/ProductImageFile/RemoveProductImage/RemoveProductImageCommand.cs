using Application_CampFinalProject.Dtos.ProductImageFile;
using Application_CampFinalProject.Repositories;
using Domain_CampFinalProject.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands
{
    public class RemoveProductImageCommand:IRequest<RemoveImageFileDTO>
    {
        public int Id { get; set; }
        public int? ImageId { get; set; }

        public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommand, RemoveImageFileDTO>
        {
            private readonly IProductReadRepository _productReadRepository;
            private readonly IProductWriteRepository _productWriteRepository;

            public RemoveProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
            {
                _productReadRepository = productReadRepository;
                _productWriteRepository = productWriteRepository;
            }

            public async Task<RemoveImageFileDTO> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
            {
                Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == request.Id);
               ProductImageFile? productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == request.ImageId);

                if (productImageFile != null)
                    product?.ProductImageFiles.Remove(productImageFile);
                await _productWriteRepository.SaveAsync();
                return new();
            }
        }
    }
}
