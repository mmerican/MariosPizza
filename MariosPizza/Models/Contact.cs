using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MariosPizza.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address required")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+\.[a-zA-Z]{2,3}$", ErrorMessage = "Email is not in the right format")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage="You must enter a message")]
        public string Message { get; set; }
    }
}