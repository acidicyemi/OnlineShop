using shop.Data.Interfaces;
using shop.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ShopDbContext _context;
        public LoginRepository(ShopDbContext context)
        {
            _context = context;
        }

        public bool CheckSeller(string email, string password)
        {
            bool status = false;
            var checkSeller = _context.Sellers
                .Where(a => a.Email == email).FirstOrDefault();
            if(checkSeller != null)
            {
                if (string.Compare(password.Hash(), checkSeller.Password) == 0)
                {
                    status = true;
                }
            }
            return status;
        }
    }
}
