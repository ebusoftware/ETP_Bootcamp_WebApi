using Application_CampFinalProject.Dtos.ShoppingListItem;
using Application_CampFinalProject.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Queries
{
    public class GetAllShoppingListItemQuery:IRequest<List<GetAllShoppingListItemDTO>>
    {
        public class GetAllShoppingListItemQueryHandler : IRequestHandler<GetAllShoppingListItemQuery, List<GetAllShoppingListItemDTO>>
        {
            private readonly IShoppingListItemReadRepository _shoppingListItemReadRepository;
            private readonly IMapper _mapper;

            public GetAllShoppingListItemQueryHandler(IShoppingListItemReadRepository shoppingListItemReadRepository, IMapper mapper)
            {
                _shoppingListItemReadRepository = shoppingListItemReadRepository;
                _mapper = mapper;
            }

            public async Task<List<GetAllShoppingListItemDTO>> Handle(GetAllShoppingListItemQuery request, CancellationToken cancellationToken)
            {
                List<GetAllShoppingListItemDTO> shoppingListItems = _shoppingListItemReadRepository.GetAll()
                            .Include(e=>e.Product).Select(e=> new GetAllShoppingListItemDTO 
                            {
                                Id= e.Id,
                                ProductName=e.Product.ProductName,
                                Quantity=e.Quantity
                            }).ToList();
                return shoppingListItems;
            }
        }
    }
}
