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

        //public RecommendationCreateViewModel()
        //{
        //}
        public Recommendation Recommendation { get; set; }


        public List<SelectListItem> Neighborhoods { get; set; }

        public RecommendationCreateViewModel(ApplicationDbContext context)
        {
            Neighborhoods = context.Neighborhood.Select(neighborhood =>

            new SelectListItem { Text = neighborhood.Name, Value = neighborhood.NeighborhoodId.ToString() }).ToList();
            _context = context;
        }

        public RecommendationCreateViewModel()
        {
        }
    }
    }




