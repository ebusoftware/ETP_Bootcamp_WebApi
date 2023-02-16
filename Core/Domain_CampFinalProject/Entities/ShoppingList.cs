using Domain_CampFinalProject.Entities.Common;
using Domain_CampFinalProject.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CampFinalProject.Entities
{
    public class ShoppingList:Entity
    {
        public string UserId { get; set; }
        public string ListName { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
        public  AppUser AppUser { get; set; }

    }
}
