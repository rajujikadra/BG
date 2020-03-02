using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BG.Models
{
    public class AccountBindingModels
    {
    }
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DisplayName("Remember")]
        public bool RememberMe { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserName { get; set; }
    }

    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Code")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid Code")]
        public string Code { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }

    public class RegisterViewModel
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
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select city.")]
        public int UserCityId { get; set; }
        [Required(ErrorMessage = "Please select state.")]
        public int UserStateId { get; set; }
        [Required(ErrorMessage = "Please select country.")]
        public int UserCountryId { get; set; }

        [Required(ErrorMessage = "Business name is required.")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Business address is required.")]
        public string BusinessAddress { get; set; }

        [Required(ErrorMessage = "Business email is required.")]
        [EmailAddress]
        [Display(Name = "Business Email")]
        public string BusinessEmailId { get; set; }

        [Required(ErrorMessage = "Business mobile number is required.")]
        public string BusinessMobileNo { get; set; }

        [Required(ErrorMessage = "Please select business city.")]
        public int BusinessCityId { get; set; }

        [Required(ErrorMessage = "Please select business state.")]
        public int BusinessStateId { get; set; }

        [Required(ErrorMessage = "Please select business country.")]
        public int BusinessCountryId { get; set; }

        [Required(ErrorMessage = "GST NO is required.")]
        public string GSTNO { get; set; }

        [Required(ErrorMessage = "Reference number is required.")]
        public string ReferenceNo { get; set; }

        [Required(ErrorMessage = "Reference name is required.")]
        public string RefName { get; set; }
        [Required(ErrorMessage = "Reference mobile is required.")]
        public string RefMobile { get; set; }
        [Required(ErrorMessage = "Reference business is required.")]
        public string RefBusiness { get; set; }

    }

}