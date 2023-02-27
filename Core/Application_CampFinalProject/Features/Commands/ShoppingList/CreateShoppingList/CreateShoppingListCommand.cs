using Application_CampFinalProject.Dtos.ShoppingList;
using Application_CampFinalProject.Repositories;
using AutoMapper;
using Domain_CampFinalProject.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands
{
    public class CreateShoppingListCommand:IRequest<CreateShoppingListDTO>
    {
        public int ItemId { get; set; }
        public string UserId { get; set; }
        public string ListName { get; set; }

        public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommand, CreateShoppingListDTO>
        {
            private readonly IMapper _mapper;
            private readonly IShoppingListWriteRepository _shoppingListWriteRepository;

            public CreateShoppingListCommandHandler(IMapper mapper, IShoppingListWriteRepository shoppingListWriteRepository)
            {
                _mapper = mapper;
                _shoppingListWriteRepository = shoppingListWriteRepository;
            }

            public async Task<CreateShoppingListDTO> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
            {
                ShoppingList mappedShoppingList = _mapper.Map<ShoppingList>(request);
                ShoppingList createdShoppingList = await _shoppingListWriteRepository.AddAsync(mappedShoppingList);
                CreateShoppingListDTO createShoppingListDTO = _mapper.Map<CreateShoppingListDTO>(createdShoppingList);
                return createShoppingListDTO;

            }
        }
    }
}
