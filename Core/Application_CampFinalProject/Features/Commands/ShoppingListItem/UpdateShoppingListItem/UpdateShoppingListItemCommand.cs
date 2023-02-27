using Application_CampFinalProject.Dtos.ShoppingListItem;
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
    public class UpdateShoppingListItemCommand:IRequest<UpdateShoppingListItemDTO>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public class UpdateShoppingListItemCommandHandler : IRequestHandler<UpdateShoppingListItemCommand, UpdateShoppingListItemDTO>
        {
            private readonly IMapper _mapper;
            private readonly IShoppingListItemWriteRepository _shoppingListItemWriteRepository;

            public UpdateShoppingListItemCommandHandler(IMapper mapper, IShoppingListItemWriteRepository shoppingListItemWriteRepository)
            {
                _mapper = mapper;
                _shoppingListItemWriteRepository = shoppingListItemWriteRepository;
            }

            public async Task<UpdateShoppingListItemDTO> Handle(UpdateShoppingListItemCommand request, CancellationToken cancellationToken)
            {
                ShoppingListItem mappedShoppingListItem = _mapper.Map<ShoppingListItem>(request);
                ShoppingListItem updatedShoppingListItem = await _shoppingListItemWriteRepository.UpdateAsync(mappedShoppingListItem);
                UpdateShoppingListItemDTO updateShoppingListItemDTO = _mapper.Map<UpdateShoppingListItemDTO>(updatedShoppingListItem);
                return updateShoppingListItemDTO;
            }
        }
    }
}
