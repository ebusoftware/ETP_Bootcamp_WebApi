using Domain_CampFinalProject.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CampFinalProject.Entities
{
    public class Category:Entity
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
