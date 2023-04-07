using Application_CampFinalProject.Dtos.Product;
using Application_CampFinalProject.Repositories;
using AutoMapper;
using Domain_CampFinalProject.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Queries
{
    public class GetAllProductQuery:IRequest<List<GetAllProductDTO>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductDTO>>
        {
            private readonly IProductReadRepository _productReadRepository;
            private readonly IMapper _mapper;

            public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
            {
                _productReadRepository = productReadRepository;
                _mapper = mapper;
            }

            public async Task<List<GetAllProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                List<GetAllProductDTO> products = _productReadRepository.GetAll(false)
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .Include(e => e.Brand)
                    .Include(e => e.Category)
                    .Include(e => e.ProductImageFiles)
                    .Select(e=> new GetAllProductDTO
                    {
                       Id=e.Id,
                       ProductName= e.ProductName,
                       Description= e.Description,
                       BrandName= e.Brand.BrandName,
                       CategoryName= e.Category.CategoryName,
                       ProductImageFile= e.ProductImageFiles,
                       IsActive= e.IsActive
                    }).ToList();
                
                return products;
                
                    
            }
        }
    }
}
