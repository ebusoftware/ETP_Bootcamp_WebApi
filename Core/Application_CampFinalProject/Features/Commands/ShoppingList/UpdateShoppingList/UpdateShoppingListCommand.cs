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
    public class UpdateShoppingListCommand:IRequest<UpdateShoppingListDTO>
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string UserId { get; set; }
        public string ListName { get; set; }

        public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommand, UpdateShoppingListDTO>
        {
            private readonly IMapper _mapper;
            private readonly IShoppingListWriteRepository _shoppingListWriteRepository;

            public UpdateShoppingListCommandHandler(IMapper mapper, IShoppingListWriteRepository shoppingListWriteRepository)
            {
                _mapper = mapper;
                _shoppingListWriteRepository = shoppingListWriteRepository;
            }

            public async Task<UpdateShoppingListDTO> Handle(UpdateShoppingListCommand request, CancellationToken cancellationToken)
            {
                ShoppingList mappedShoppingList = _mapper.Map<ShoppingList>(request);
                ShoppingList updatedShoppingList = await _shoppingListWriteRepository.UpdateAsync(mappedShoppingList);
                UpdateShoppingListDTO updateShoppingListDTO = _mapper.Map<UpdateShoppingListDTO>(updatedShoppingList);
                return updateShoppingListDTO;
            }
        }
    }
}
