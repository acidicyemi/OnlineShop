using shop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace shop.ViewModel
{
    public class RegisterSellerViewModel
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string Dob { get; set; }
        [Required]
        public int ScategoryId { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string ShopName { get; set; }
        [Required]
        public string Address { get; set; }

        public string BrandImageUrl { get; set; }
        [Required]
        public IFormFile BrandImage { get; set; }
        [Required]
        public IFormFile IdCard { get; set; }

        public string IdCardUrl { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum of 6 characters is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password is different. Please check")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public Scategory Scategory { get; set; }


        public List<Scategory> ScategoryList { get; set; }


    }
}
