using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Models
{
    public class Scategory
    {
        public int ScategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; }
    }
}
