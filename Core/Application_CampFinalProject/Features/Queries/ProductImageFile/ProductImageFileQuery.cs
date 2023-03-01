using Application_CampFinalProject.Dtos.Product;
using Application_CampFinalProject.Dtos.ProductImageFile;
using Application_CampFinalProject.Repositories;
using Domain_CampFinalProject.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Queries.ProductImageFile
{
    public class ProductImageFileQuery:IRequest<List<GetProductImageFileDTO>>
    {
        public int Id { get; set; }

        public class ProductImageFileQueryHandler : IRequestHandler<ProductImageFileQuery, List<GetProductImageFileDTO>>
        {
            private readonly IProductReadRepository _productReadRepository;
            private readonly IConfiguration configuration;

            public ProductImageFileQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration)
            {
                _productReadRepository = productReadRepository;
                this.configuration = configuration;
            }

            public async Task<List<GetProductImageFileDTO>> Handle(ProductImageFileQuery request, CancellationToken cancellationToken)
            {
                Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                  .FirstOrDefaultAsync(p => p.Id == (request.Id));
                return product?.ProductImageFiles.Select(p => new GetProductImageFileDTO
                {
                    Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
                    FileName = p.FileName,
                    Id = p.Id
                }).ToList();
            }
        }
    }
}
