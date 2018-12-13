using shop.Data;
using shop.Data.Interfaces;
using shop.Data.Models;
using shop.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopDbContext context) : base(context)
        {

        }
        public IEnumerable<Product> FindWithSeller(Func<Product, bool> predicate)
        {
            return _context.Products
                .Include(a => a.Seller)
                .Where(predicate);
        }

        public IEnumerable<Product> GetAllWithPcategory()
        {
            return _context.Products.Include(a => a.Pcategory);
        }

        public IEnumerable<Product> GetAllWithSeller()
        {
            return _context.Products.Include(a => a.Seller);
        }
    }
}
