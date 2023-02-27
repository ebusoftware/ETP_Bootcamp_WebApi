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
    public class CreateShoppingListItemCommand:IRequest<CreateShoppingListItemDTO>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public class CreateShoppingListItemCommandHandler : IRequestHandler<CreateShoppingListItemCommand, CreateShoppingListItemDTO>
        {
            private readonly IMapper _mapper;
            private readonly IShoppingListItemWriteRepository _shoppingListItemWriteRepository;

            public CreateShoppingListItemCommandHandler(IMapper mapper, IShoppingListItemWriteRepository shoppingListItemWriteRepository)
            {
                _mapper = mapper;
                _shoppingListItemWriteRepository = shoppingListItemWriteRepository;
            }

            public async Task<CreateShoppingListItemDTO> Handle(CreateShoppingListItemCommand request, CancellationToken cancellationToken)
            {
                ShoppingListItem mappedShoppingListItem = _mapper.Map<ShoppingListItem>(request);
                ShoppingListItem createdShoppingListItem = await _shoppingListItemWriteRepository.AddAsync(mappedShoppingListItem);
                CreateShoppingListItemDTO createShoppingListItemDTO = _mapper.Map<CreateShoppingListItemDTO>(createdShoppingListItem);
                return createShoppingListItemDTO;
            }
        }
    }
}
