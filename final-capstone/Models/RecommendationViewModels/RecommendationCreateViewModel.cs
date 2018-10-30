using final_capstone.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace final_capstone.Models.RecommendationViewModels
{
    public class RecommendationCreateViewModel
    {
        private readonly ApplicationDbContext _context;

        public RecommendationCreateViewModel()
        {
        }

        public RecommendationCreateViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Recommendation Recommendation { get; set; }
    }
}


