using API.CampFinalProjectAPI.Contexts;
using Application_CampFinalProject.Repositories;
using Domain_CampFinalProject.Entities;

namespace Persistence_CampFinalProject.Repositories
{
    public class ShoppingListReadRepository : ReadRepository<ShoppingList>, IShoppingListReadRepository
{
    public ShoppingListReadRepository(ShoppingListDbContext context) : base(context)
    {
    }
}
}

