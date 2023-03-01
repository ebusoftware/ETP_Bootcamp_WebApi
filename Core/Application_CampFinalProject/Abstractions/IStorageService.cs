using Application_CampFinalProject.Abstractions.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Abstractions
{
    public interface IStorageService:IStorage
    {
        public string StorageName { get; }  
    }
}
