using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain_CampFinalProject.Entities.Common
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        virtual public DateTime? UpdatedDate { get; set; }
    }
}
