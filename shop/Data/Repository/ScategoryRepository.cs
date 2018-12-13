using shop.Data;
using shop.Data.Interfaces;
using shop.Data.Models;
using shop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Data.Repository
{
    public class ScategoryRepository : Repository<Scategory>, IScategoryRepository
    {
        public ScategoryRepository(ShopDbContext context) : base(context)
        {
        }

   

        //public IEnumerable<Scategory> GetAllWithSellers()
        //{
        //    return _context.Scategories.Include(a => a.Sellers);
        //}
    }
}
