using shop.Data;
using shop.Data.Interfaces;
using shop.Data.Models;
using shop.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ecommerce.Data.Repository
{
    public class SellerRepository : Repository<Seller>, ISellerRepository
    {
        public SellerRepository(ShopDbContext context) : base(context)
        {
        }


        public IEnumerable<Seller> GetAllWithProducts()
        {
            return _context.Sellers.Include(a => a.Products);
        }

        public Seller GetWithProduct(int id)
        {
            return _context.Sellers
                .Where(a => a.SellerId == id)
                .Include(a => a.Products)
                .FirstOrDefault();
        }

        public bool IsEmailExist(string email)
        {
            var exist = _context.Sellers.Where(a => a.Email == email).FirstOrDefault();
            return exist != null;
        }

        public bool ActivateSeller(string code)
        {
            var check = _context.Sellers
                 .Where(a => a.ActivationCode == code)
                 .FirstOrDefault();
            if(check != null)
            {
                check.MailVerified = true;
                Save();
            }

            return check != null;
        }

        
    }
}
