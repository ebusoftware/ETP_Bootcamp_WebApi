﻿using API.CampFinalProjectAPI.Contexts;
using Application_CampFinalProject.Repositories;
using Domain_CampFinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_CampFinalProject.Repositories
{
    public class ShoppingListWriteRepository : WriteRepository<ShoppingList>, IShoppingListWriteRepository
    {
        public ShoppingListWriteRepository(ShoppingListDbContext context) : base(context)
        {
        }
    }
}
