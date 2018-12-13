using shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Interfaces
{
    public interface IPcategoryRepository : IRepository<Pcategory>
    {
        IEnumerable<Pcategory> GetAllWithProducts();
    }
}
