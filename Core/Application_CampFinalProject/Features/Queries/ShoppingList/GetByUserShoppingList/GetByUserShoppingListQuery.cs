using Application_CampFinalProject.Dtos.ShoppingList;
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
    public class GetByUserShoppingListQuery:IRequest<List<GetByUserDTO>>
    {
        public string UserId { get; set; }
        public class GetByUserShoppingListQueryHandler : IRequestHandler<GetByUserShoppingListQuery, List<GetByUserDTO>>
        {
            private readonly IShoppingListReadRepository _shoppingListReadRepository;

            public GetByUserShoppingListQueryHandler(IShoppingListReadRepository shoppingListReadRepository)
            {
                _shoppingListReadRepository = shoppingListReadRepository;
            }

            public async Task<List<GetByUserDTO>> Handle(GetByUserShoppingListQuery request, CancellationToken cancellationToken)
            {
                List<GetByUserDTO> datas = _shoppingListReadRepository.GetAll()
                    .Include(e => e.AppUser)
                    .Include(e => e.ShoppingListItem)
                    .ThenInclude(e=>e.Product)
                    .Where(e=>e.UserId == request.UserId)
                    .Select(e=> new GetByUserDTO
                    {
                        ProductName=e.ShoppingListItem.Product.ProductName,
                        ListName=e.ListName,
                        UserName=e.AppUser.UserName

                    }).ToList();
                return datas;
            }
        }
    }
}
