using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Dtos.ShoppingListItem
{
    public class GetAllShoppingListItemDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
