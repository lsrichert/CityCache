using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_capstone.Models
{
    public class Neighborhood
{
        [Key]
        public int NeighborhoodId { get; set; }

        [Required]
        public string Name { get; set; }
}
}
