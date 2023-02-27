using Domain_CampFinalProject.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CampFinalProject.Entities
{
    public class Brand:Entity
    {
        public string BrandName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
