using final_capstone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_capstone.Models.RecommendationViewModels
{
    public class RecommendationEditViewModel
    {
        private readonly ApplicationDbContext _context;


        public Recommendation Recommendation { get; set; }

        public int RecommendationId { get; set; }

        public IEnumerable<SelectListItem> RecommendationTypes { get; set; }
        public IEnumerable<SelectListItem> Neighborhoods { get; set; }

        public RecommendationEditViewModel(ApplicationDbContext context)
        {
            Neighborhoods = context.Neighborhood.Select(neighborhood =>
            new SelectListItem { Text = neighborhood.Name, Value = neighborhood.NeighborhoodId.ToString() }).ToList();
            _context = context;

            RecommendationTypes = context.RecommendationType.Select(recommendationtype =>
            new SelectListItem { Text = recommendationtype.Name, Value = recommendationtype.RecommendationTypeId.ToString() }).ToList();
            _context = context;
        }

        public RecommendationEditViewModel()
        {
    }
    }
}

