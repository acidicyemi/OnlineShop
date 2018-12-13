using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string BrandImageUrl { get; set; }
        public string Address { get; set; }
        public string ShopName { get; set; }
        public string IdCard { get; set; }
        public int ScategoryId { get; set; }
        public virtual Scategory Scategory { get; set; }
        public string Dob { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool MailVerified { get; set; }
        public bool IdVerified { get; set; }
        public string ActivationCode { get; set; }
        public string FacebookName { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramName { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterName { get; set; }
        public string TwitterUrl { get; set; }
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
