using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
