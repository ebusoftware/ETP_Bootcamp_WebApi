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
    public class DeleteCategoryCommand :IRequest<DeleteCategoryDTO>
    {
        public int Id { get; set; }
        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryDTO>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryWriteRepository _categoryWriteRepository;

            public DeleteCategoryCommandHandler(IMapper mapper, ICategoryWriteRepository categoryWriteRepository)
            {
                _mapper = mapper;
                _categoryWriteRepository = categoryWriteRepository;
            }

            public async Task<DeleteCategoryDTO> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                Category mappeddCategory = _mapper.Map<Category>(request);
                Category deletedCategory = await _categoryWriteRepository.RemoveAsync(mappeddCategory);
                DeleteCategoryDTO deletedCategoryDTO = _mapper.Map<DeleteCategoryDTO>(deletedCategory);
                return deletedCategoryDTO;
            }
        }
    }
}
