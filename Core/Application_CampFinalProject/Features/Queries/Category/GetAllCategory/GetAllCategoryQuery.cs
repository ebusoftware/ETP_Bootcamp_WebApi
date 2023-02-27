using Application_CampFinalProject.Dtos.Category;
using Application_CampFinalProject.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Queries
{
    public class GetAllCategoryQuery:IRequest<List<GetAllCategoryDTO>>
    {
        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<GetAllCategoryDTO>>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryReadRepository _categoryReadRepository;

            public GetAllCategoryQueryHandler(IMapper mapper, ICategoryReadRepository categoryReadRepository)
            {
                _mapper = mapper;
                _categoryReadRepository = categoryReadRepository;
            }

            public async Task<List<GetAllCategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _categoryReadRepository.GetAllAsync();
               return categories.Select(e=> new GetAllCategoryDTO 
                {
                    Id=e.Id,
                    CategoryName= e.CategoryName,
                    Description=e.Description
                }).ToList();
            }
        }
    }
}
