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
    public class UpdateCategoryCommand:IRequest<UpdateCategoryDTO>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryDTO>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryWriteRepository _categoryWriteRepository;

            public UpdateCategoryCommandHandler(IMapper mapper, ICategoryWriteRepository categoryWriteRepository)
            {
                _mapper = mapper;
                _categoryWriteRepository = categoryWriteRepository;
            }

            public async Task<UpdateCategoryDTO> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category mappedCategory = _mapper.Map<Category>(request);
                Category updatedCategory = await _categoryWriteRepository.UpdateAsync(mappedCategory);
                UpdateCategoryDTO updateCategoryDTO = _mapper.Map<UpdateCategoryDTO>(updatedCategory);
                return updateCategoryDTO;
            }
        }
    }
}
