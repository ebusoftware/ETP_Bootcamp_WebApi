using Application_CampFinalProject.Dtos.ShoppingList;
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
    public class DeleteShoppingListCommand:IRequest<DeleteShoppingListDTO>
    {
        public int Id { get; set; }
        public class DeleteShoppingListCommandHandler : IRequestHandler<DeleteShoppingListCommand, DeleteShoppingListDTO>
        {
            private readonly IMapper _mapper;
            private readonly IShoppingListWriteRepository _shoppingListWriteRepository;

            public DeleteShoppingListCommandHandler(IMapper mapper, IShoppingListWriteRepository shoppingListWriteRepository)
            {
                _mapper = mapper;
                _shoppingListWriteRepository = shoppingListWriteRepository;
            }

            public async Task<DeleteShoppingListDTO> Handle(DeleteShoppingListCommand request, CancellationToken cancellationToken)
            {
                ShoppingList mappedShoppingList = _mapper.Map<ShoppingList>(request);
                ShoppingList deletedShoppingList = await _shoppingListWriteRepository.RemoveAsync(mappedShoppingList);
                DeleteShoppingListDTO deleteShoppingListDTO = _mapper.Map<DeleteShoppingListDTO>(deletedShoppingList);
                return deleteShoppingListDTO;
            }
        }
    }
}
