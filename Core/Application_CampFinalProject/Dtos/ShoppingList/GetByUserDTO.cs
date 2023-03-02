using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Dtos.ShoppingList
{
    public class GetByUserDTO
    {
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public string ListName { get; set; }
    }
}
