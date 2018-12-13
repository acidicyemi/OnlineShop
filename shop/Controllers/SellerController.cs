using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using shop.Data.Interfaces;
using shop.Data.Models;
using shop.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Extensions;
using System.Net.Mail;
using System.Net;

namespace ecommerce.Controllers
{
    public class SellerController : Controller
    {

        private readonly IScategoryRepository _scategoryRepository;
        private readonly ISellerRepository _sellerRepository;
        RegisterSellerViewModel registerSellerViewModel = new RegisterSellerViewModel();

        public SellerController(IScategoryRepository scategoryRepository, ISellerRepository sellerRepository)
        {
            _scategoryRepository = scategoryRepository;
            _sellerRepository = sellerRepository;
        }

        public IActionResult Register()
        {
            Initializer();

            return View("Register", registerSellerViewModel);
        }

        //public IActionResult Success()
        //{
        //    return View("Success");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterSellerViewModel item)
        {
            bool Status = false;
            string Message = "";

            Initializer();

            //MOdel Validation
            if (ModelState.IsValid)
            {
                #region //Email already exist
                var IsExist = _sellerRepository.IsEmailExist(item.Email);
                if (IsExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist in our records");
                    return View("Register", registerSellerViewModel);
                }
                #endregion 
            }
            else
            {
                Message = "Invalid Request";
                return View("Register", registerSellerViewModel);
            }

            var seller = new Seller();
            var idFile = item.IdCard;
            var bFile = item.BrandImage;
            
                if (idFile.Length > 0)
                {
                    if (bFile.Length > 0)
                    {
                        var bFileSplit = bFile.FileName.Split('.');
                        var bFileExtension = bFileSplit.Last();
                        var bFileName = Guid.NewGuid() + "." + bFileExtension;
                        var bPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/brandImages", bFileName);
                        //string fileName = Path.Combine(_hostingEnvironment.WebRootPath, Path.GetFileName(file));
                        using (var bStream = new FileStream(bPath, FileMode.Create))
                        {
                            await bFile.CopyToAsync(bStream);
                        }
                        item.BrandImageUrl = $"/images/brandImages/{bFileName}";
                    }
                    var idFileSplit = idFile.FileName.Split('.');
                    var idFileExtension = idFileSplit.Last();
                    var idFileName = Guid.NewGuid() + "." + idFileExtension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/sellerIdCard", idFileName);
                    //string fileName = Path.Combine(_hostingEnvironment.WebRootPath, Path.GetFileName(file));
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await idFile.CopyToAsync(stream);
                    }
                    var guid = Guid.NewGuid();
                    string ac = guid.ToString();
                    item.Password = item.Password.Hash();


                    item.IdCardUrl = $"/images/sellerIdCard/{idFileName}";
                    seller.FirstName = item.FirstName;
                    seller.MiddleName = item.MiddleName;
                    seller.Lastname = item.Lastname;
                    seller.Address = item.Address;
                    seller.BrandImageUrl = item.BrandImageUrl;
                    seller.IdCard = item.IdCardUrl;
                    seller.Dob = item.Dob;
                    seller.ShopName = item.ShopName;
                    seller.Email = item.Email;
                    seller.ScategoryId = item.ScategoryId;
                    seller.Phone = item.Phone;
                    seller.MailVerified = false;
                    seller.IdVerified = false;
                    seller.ActivationCode = ac;
                    seller.Password = item.Password;

                    _sellerRepository.Create(seller);
                //Send email
               // SendVerificationMail(item.Email, ac);
                //try
                //{
                //    SendVerificationMail(item.Email, ac);
                //}
                //catch (Exception)
                //{
                    
                //}   
                Message = "Registration successfully done. Please check your"+
                    " mail ("+item.Email+") for an activation link to verify your account";
                Status = true;
                }

            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View("Register", registerSellerViewModel);
        }

        

        [NonAction]
        public void SendVerificationMail(string email, string activationCode)
        {
            //var uriBuilder = new UriBuilder
            //{
            //    Scheme = Request.Scheme,
            //    Host = Request.Host.ToString(),
            //    Path = $"/user/VerifyAccount/{activationCode}"
            //};
            var link = "http://localhost:50470/VerifyAccount/Seller?code=" + activationCode;
            //var link = uriBuilder.Uri.AbsoluteUri;

            var fromEmail = new MailAddress("damiadehjames@gmail.com", "My Shop");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "wedding2000";
            string subject = "Your account is sucessfully created";
            string body = "<br/> Great Job !!!!<br/><br/>" +
                "Your shop has been created successfully. To start selling, kindly " +
                "click on the link below to verify your account. <br/>" +
                " <a href='" + link + "'>" + link + "</a>";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            })
                smtp.Send(message);

        }

        [NonAction]
        public void Initializer()
        {
            registerSellerViewModel.ScategoryList = new List<Scategory>();
            registerSellerViewModel.ScategoryList = _scategoryRepository.GetAll().ToList();

            registerSellerViewModel.Scategory = new Scategory();
        }

    }
}
