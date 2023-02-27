using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Dtos.Product
{
    public class GetAllProductDTO
    {
        public int Id { get; set; }

        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public object ProductImageFile { get; set; }
        public bool IsActive { get; set; }

    }
}
