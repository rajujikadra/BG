using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BG.Models
{
    public class CounterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Passwords must contain at least six characters long, including uppercase, lowercase letters, numbers and symbol.")]
        [MembershipPassword(MinRequiredNonAlphanumericCharacters = 1,
         MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
         ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
         MinRequiredPasswordLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select role.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int UserCityId { get; set; }
        public int UserStateId { get; set; }
        public int UserCountryId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessEmailId { get; set; }
        public string BusinessMobileNo { get; set; }
        public int BusinessCityId { get; set; }
        public int BusinessStateId { get; set; }
        public int BusinessCountryId { get; set; }
        public string GSTNO { get; set; }
        public string ReferenceNo { get; set; }
        public string RefName { get; set; }
        public string RefMobile { get; set; }
        public string RefBusiness { get; set; }
        public bool IsActive { get; set; }
    }
}