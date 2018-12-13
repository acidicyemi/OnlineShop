using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop.Data.Interfaces;

namespace shop.Controllers
{
    public class VerifyAccountController : Controller
    {
        private readonly ISellerRepository _sellerRepository;
        public VerifyAccountController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        [HttpGet]
        public ActionResult Seller(string code)
        {
            bool Status = false;
            bool updateSeller = _sellerRepository.ActivateSeller(code);
            if (updateSeller)
            {
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request";
                return View("Activated");
            }
            ViewBag.Status = Status;
            return View("Activated");

        }
    }
}