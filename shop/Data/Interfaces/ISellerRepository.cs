using shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Interfaces
{
    public interface ISellerRepository : IRepository<Seller>
    {
        IEnumerable<Seller> GetAllWithProducts();
        Seller GetWithProduct(int id);
        bool IsEmailExist(string email);
        bool ActivateSeller(string code);
        //void SendVerificationMail(string email, string activationCode);
    }
}
