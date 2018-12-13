using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Data.Interfaces;
using shop.ViewModel;

namespace ecommerce.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        [HttpGet]
        public ActionResult Seller()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Seller(LoginSellerViewModel item)
        {
            string Message = "";
            bool Status = true;
            //MOdel Validation
            if (ModelState.IsValid)
            {
               bool isRegistered = _loginRepository.CheckSeller(item.Username, item.Password);
                if (!isRegistered)
                {
                    Message = "Invalid credential provided";
                    ViewBag.Message = Message;
                    ViewBag.Status = Status;
                    return View();
                }
                return RedirectToAction("Index", "");

            }
            else
            {
                Message = "Invalid credential provided";
                ViewBag.Message = Message;
                ViewBag.Status = Status;
                return View();
            }
            
        }

        public bool checkUser()
        {

        }
        

        

        

        
    }
}