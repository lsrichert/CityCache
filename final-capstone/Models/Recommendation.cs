using final_capstone;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace final_capstone.Models
{
    public class Recommendation
    {
        [Key]
        public int RecommendationId { get; set; }

        [Required]
        [Display(Name = "Place")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please shorten the description to 50 characters")]
        public string Description { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "Website")]
        public string WebsiteURL { get; set; }

        [Required]
        public bool DefaultView { get; set; }

        //[Required]
        public int ApplicationUserId { get; set; }

        //[Required]
        public int NeighborhoodId { get; set; }

        //[Required]
        public int RecommendationTypeId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public Neighborhood Neighborhood { get; set; }

        public RecommendationType RecommendationType { get; set; } 


}
}
