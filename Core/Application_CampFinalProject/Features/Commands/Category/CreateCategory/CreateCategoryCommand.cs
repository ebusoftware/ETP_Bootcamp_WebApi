using Application_CampFinalProject.Dtos.Category;
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
    public class CreateCategoryCommand:IRequest<CreateCategoryDTO>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryDTO>
        {
            
            private readonly IMapper _mapper;
            private readonly ICategoryWriteRepository _categoryWriteRepository;

            public CreateCategoryCommandHandler(IMapper mapper, ICategoryWriteRepository categoryWriteRepository)
            {
                _mapper = mapper;
                _categoryWriteRepository = categoryWriteRepository;
            }

            public async Task<CreateCategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category mappedCategory = _mapper.Map<Category>(request);
                Category createdCategory = await _categoryWriteRepository.AddAsync(mappedCategory);
                CreateCategoryDTO createCategoryDTO = _mapper.Map<CreateCategoryDTO>(createdCategory);
                return createCategoryDTO;
            }
        }
    }
}
