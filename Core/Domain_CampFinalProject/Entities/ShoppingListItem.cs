using Domain_CampFinalProject.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CampFinalProject.Entities
{
    public class ShoppingListItem:Entity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
