using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MariosPizza.Models
{
    public class MenuCategory
    {
        [Key]
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

    }
}