using Domain_CampFinalProject.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CampFinalProject.Entities
{
    public class Product:Entity
    {
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public Category? Category { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
