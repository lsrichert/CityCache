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
        [Display(Name = "Place (Required)")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description (Required)")]
        [StringLength(50, ErrorMessage = "Please shorten the description to 50 characters")]
        public string Description { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        //[DataType(DataType.Url)]
        [Display(Name = "Website")]
        public string WebsiteURL { get; set; }

        //[Required]
        public bool DefaultView { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        [Display(Name = "Neighborhood")]
        public int NeighborhoodId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int RecommendationTypeId { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Neighborhood Neighborhood { get; set; }

        public RecommendationType RecommendationType { get; set; } 


}
}
