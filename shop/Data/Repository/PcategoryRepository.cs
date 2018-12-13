using shop.Data.Interfaces;
using shop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop.Data.Repository;
using shop.Data;

namespace ecommerce.Data.Repository
{
    public class PcategoryRepository : Repository<Pcategory>, IPcategoryRepository
    {
        public PcategoryRepository(ShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Pcategory> GetAllWithProducts()
        {
            return _context.Pcategories.Include(a => a.Products);
        }
    }
}
