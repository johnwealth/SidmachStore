using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long")]
        public string Name { get; set; }

        [Required]
        public Double Price { get; set; }

        [Display(Name = "Category Type")]
        public Category Category { get; set; }

        public byte CategoryId { get; set; }

    }
}




