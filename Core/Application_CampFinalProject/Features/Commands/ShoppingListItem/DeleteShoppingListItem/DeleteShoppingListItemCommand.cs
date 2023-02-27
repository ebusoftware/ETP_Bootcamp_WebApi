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
    public class DeleteShoppingListItemCommand:IRequest<DeleteShoppingListItemDTO>
    {
        public int Id { get; set; }
        public class DeleteShoppingListItemComandHandler : IRequestHandler<DeleteShoppingListItemCommand, DeleteShoppingListItemDTO>
        {
            private readonly IMapper _mapper;
            private readonly IShoppingListItemWriteRepository _shoppingListItemWriteRepository;

            public DeleteShoppingListItemComandHandler(IMapper mapper, IShoppingListItemWriteRepository shoppingListItemWriteRepository
                )
            {
                _mapper = mapper;
                _shoppingListItemWriteRepository = shoppingListItemWriteRepository;
            }

            public async Task<DeleteShoppingListItemDTO> Handle(DeleteShoppingListItemCommand request, CancellationToken cancellationToken)
            {
                ShoppingListItem mappedListItem = _mapper.Map<ShoppingListItem>( request );
                ShoppingListItem deletedListItem = await _shoppingListItemWriteRepository.RemoveAsync( mappedListItem );
                DeleteShoppingListItemDTO  deleteShoppingListItemDTO = _mapper.Map<DeleteShoppingListItemDTO>( deletedListItem );
                return deleteShoppingListItemDTO;
            }
        }
    }
}
