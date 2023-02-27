using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CampFinalProject.Entities
{
    public class ProductImageFile : File
    {
        public bool Showcase { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
