using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Dtos.Category
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
