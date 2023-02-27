
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Dtos.ShoppingListDTO
{
    public class GetAllShoppingListDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string UserName { get; set; }
        public string ListName { get; set; }
    }
}
