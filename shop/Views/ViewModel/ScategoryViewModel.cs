using shop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.ViewModel
{
    public class ScategoryViewModel
    {
        [BindProperty]
        public Scategory Scategory { get; set; }

        public List<Scategory> ScategoryList { get; set; }
    }
}
