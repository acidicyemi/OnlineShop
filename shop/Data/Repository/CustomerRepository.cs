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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopDbContext context) : base(context)
        {

        }
    }
}
