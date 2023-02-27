using Application_CampFinalProject.Dtos.ShoppingListDTO;
using Application_CampFinalProject.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Queries
{
    public class GetAllShoppingListQuery:IRequest<List<GetAllShoppingListDTO>>
    {
        public class GetAllShoppingListQueryHandler : IRequestHandler<GetAllShoppingListQuery, List<GetAllShoppingListDTO>>
        {
            private readonly IShoppingListReadRepository _shoppingListReadRepository;

            public GetAllShoppingListQueryHandler(IShoppingListReadRepository shoppingListReadRepository)
            {
                _shoppingListReadRepository = shoppingListReadRepository;
            }

            public async Task<List<GetAllShoppingListDTO>> Handle(GetAllShoppingListQuery request, CancellationToken cancellationToken)
            {
                List<GetAllShoppingListDTO> datas = _shoppingListReadRepository.GetAll(false)
                            .Include(e => e.AppUser)
                            .Include(e => e.ShoppingListItem)
                            .ThenInclude(e=>e.Product)
                            .Select(e=> new GetAllShoppingListDTO 
                            {
                                Id= e.Id,
                                UserName=e.AppUser.UserName,
                                ListName=e.ListName,
                                ItemName=e.ShoppingListItem.Product.ProductName
                            }).ToList();
                return datas;
            }
        }
    }
}
