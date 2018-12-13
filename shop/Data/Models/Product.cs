using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string fImageUrl { get; set; }
        public string sImageUrl { get; set; }
        public string tImageUrl { get; set; }
        public bool Status { get; set; }
        public decimal Rating { get; set; }
        public int Quantity { get; set; }
        public int PcategoryID { get; set; }
        public virtual Pcategory Pcategory { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
