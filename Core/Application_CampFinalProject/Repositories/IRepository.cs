using Domain_CampFinalProject.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        DbSet<T> Table { get; }
    }
}
