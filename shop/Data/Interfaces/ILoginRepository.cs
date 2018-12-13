using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Interfaces
{
    public interface ILoginRepository
    {
        bool CheckSeller(string email, string password);

    }
}
