using Application_CampFinalProject.Abstractions;
using Application_CampFinalProject.Dtos.ProductImageFile;
using Application_CampFinalProject.Repositories;
using Domain_CampFinalProject.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands
{
    public class UploadProductImageCommand : IRequest<UploadImageFileDTO>
    {
        public int Id { get; set; }
        public IFormFileCollection? Files { get; set; }

        public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand, UploadImageFileDTO>
        {
            private readonly IProductReadRepository _productReadRepository;
            private readonly IStorageService _storageService;
            private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

            public UploadProductImageCommandHandler(IProductReadRepository productReadRepository, IStorageService storageService, IProductImageFileWriteRepository productImageFileWriteRepository)
            {
                _productReadRepository = productReadRepository;
                _storageService = storageService;
                _productImageFileWriteRepository = productImageFileWriteRepository;
            }

            public async Task<UploadImageFileDTO> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
            {
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("product-images", request.Files);


                Product product = await _productReadRepository.GetByIdAsync(request.Id);


                await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImageFile
                {
                    FileName = r.fileName,
                    Path = r.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    Products = new List<Product>() { product }
                }).ToList());

                await _productImageFileWriteRepository.SaveAsync();

                return new();
            }
        }
    }
}
