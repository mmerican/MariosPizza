using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MariosPizza.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name of the store is required")]
        public string Name {get; set;}

        [Required(ErrorMessage="Address must be filled out")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        
        [Required(ErrorMessage="City must be filled out")]
        public string City { get; set; }
        
        [Required(ErrorMessage="State must be filled out")]
        [StringLength(2, ErrorMessage="State must be maximum of two letters")]
        [Display(Name="State (2 letter abreviation")]
        public string State { get; set; }
        
        [Required(ErrorMessage="Zip code must be filled out")]
        [RegularExpression(@"^\d{5}$", ErrorMessage="Zipcode is not in the correct format")]
        [Display(Name="Zip Code (5 digit)")]
        public string Zip { get; set; }
        
        public string Location { get; set; }
        
        [Required(ErrorMessage="Hours of operation must be filled out")]
        public string Hours { get; set; }
        
        [Display(Name="Happy Hour (when)")]
        public string HappyHour { get; set; }
        
        public string Manager { get; set; }
        
        [Required(ErrorMessage="Phone number must be filled out")]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage="Phone number should contain only numbers")]
        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }
        
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Fax number should contain only numbers")]
        [Display(Name="Fax Number")]
        public string FaxNumber { get; set; }
        
        [RegularExpression(@"^\w+@[a-zA-Z_]+\.[a-zA-Z]{2,3}$", ErrorMessage="Email is not in the right format")]
        public string Email { get; set; }

    }
}