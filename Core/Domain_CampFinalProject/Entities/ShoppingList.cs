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
        public int ItemId { get; set; }
        public string UserId { get; set; }
        public string ListName { get; set; }

        public bool IsActive { get; set; } = true;

        public ShoppingListItem ShoppingListItem { get; set; }
        public  AppUser AppUser { get; set; }

    }
}
