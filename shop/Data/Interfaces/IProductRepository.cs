using shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllWithSeller();
        IEnumerable<Product> FindWithSeller(Func<Product, bool> predicate);
        IEnumerable<Product> GetAllWithPcategory();
    }
}
