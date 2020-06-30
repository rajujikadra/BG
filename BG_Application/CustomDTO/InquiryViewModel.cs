using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BG_Application.CustomDTO
{
    public class InquiryViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Name")]
        public string InquiryName { get; set; }
        [Required(ErrorMessage = "Please enter company name")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter company address")]
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }
        [Required(ErrorMessage = "Please select country")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public string Country { get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        public string State { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter comments")]
        [Display(Name = "Comments")]
        public string Comments { get; set; }

        public bool? IsResolve { get; set; }
    }
}
