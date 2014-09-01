using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MariosPizza.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name of Menu item required")]
        [StringLength(40,ErrorMessage="Menu item must be less than 40 characters")]
        [Display(Name="Item Name")]
        public String ItemName { get; set; }

        public String Availability { get; set; }

        public String Description { get; set; }

        [Range(0, 10000, ErrorMessage="Price must be between 0 and 10000")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual MenuCategory Category { get; set; }

        [Required]
        [Display(Name="Advertise as a New Item?")]
        public bool NewItem { get; set; }

        [Required]
        [Display(Name="Advertise as Limited Time Only?")]
        public bool Limited { get; set; }

    }
}