using final_capstone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace final_capstone.Models.RecommendationViewModels
{
    public class RecommendationCreateViewModel
    {
        private readonly ApplicationDbContext _context;


        public Recommendation Recommendation { get; set; }

        public int RecommendationId { get; set; }

        public IEnumerable<SelectListItem> RecommendationTypes { get; set; }
        public IEnumerable<SelectListItem> Neighborhoods { get; set; }

        public RecommendationCreateViewModel(ApplicationDbContext context)
        {
            Neighborhoods = context.Neighborhood.Select(neighborhood =>
            new SelectListItem { Text = neighborhood.Name, Value = neighborhood.NeighborhoodId.ToString() }).ToList();
            _context = context;

            RecommendationTypes = context.RecommendationType.Select(recommendationtype =>
            new SelectListItem { Text = recommendationtype.Name, Value = recommendationtype.RecommendationTypeId.ToString() }).ToList();
            _context = context;
        }

        public RecommendationCreateViewModel()
        {
        }
    }
}




