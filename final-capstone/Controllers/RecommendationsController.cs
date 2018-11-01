using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using final_capstone.Data;
using final_capstone.Models;
using final_capstone.Models.RecommendationViewModels;

namespace final_capstone.Controllers
{
    public class RecommendationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecommendationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recommendations
  
        public async Task<IActionResult> Index(string searchString)
        {
            var applicationDbContext = _context.Recommendation.Include(r => r.Neighborhood).Include(r => r.RecommendationType);

            //var recommendations = from r in _context.Recommendation
            //             select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                var searchResults = _context.Recommendation.Include(r => r.Neighborhood).Include(r => r.RecommendationType).Where(r => r.Neighborhood.Name.Contains(searchString));
                return View(await searchResults.ToListAsync());
            }

            return View(await applicationDbContext.ToListAsync());

            //var applicationDbContext = _context.Recommendation.Include(r => r.Neighborhood).Include(r => r.RecommendationType);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recommendations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendation = await _context.Recommendation
                .Include(r => r.Neighborhood)
                .Include(r => r.RecommendationType)
                .FirstOrDefaultAsync(m => m.RecommendationId == id);
            if (recommendation == null)
            {
                return NotFound();
            }

            return View(recommendation);
        }

        // GET: Recommendations/Create
        public IActionResult Create()
        {
            RecommendationCreateViewModel createRecommendation = new RecommendationCreateViewModel(_context);
            return View(createRecommendation);

            //ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhood, "NeighborhoodId", "Name");
            //ViewData["RecommendationTypeId"] = new SelectList(_context.RecommendationType, "RecommendationTypeId", "Name");
            //return View();
        }

        // POST: Recommendations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecommendationId,Name,Description,StreetAddress,WebsiteURL,DefaultView,ApplicationUserId,NeighborhoodId,RecommendationTypeId")] Recommendation recommendation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recommendation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            RecommendationCreateViewModel createRecommendation = new RecommendationCreateViewModel();
            return View(createRecommendation);

            //ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhood, "NeighborhoodId", "Name", recommendation.NeighborhoodId);
            //ViewData["RecommendationTypeId"] = new SelectList(_context.RecommendationType, "RecommendationTypeId", "Name", recommendation.RecommendationTypeId);
            //return View(recommendation);
        }

        // GET: Recommendations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendation = await _context.Recommendation.FindAsync(id);
            if (recommendation == null)
            {
                return NotFound();
            }

            RecommendationEditViewModel editRecommendation = new RecommendationEditViewModel(_context);
            return View(editRecommendation);

            //ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhood, "NeighborhoodId", "Name", recommendation.NeighborhoodId);
            //ViewData["RecommendationTypeId"] = new SelectList(_context.RecommendationType, "RecommendationTypeId", "Name", recommendation.RecommendationTypeId);
            //return View(recommendation);
        }

        // POST: Recommendations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecommendationId,Name,Description,StreetAddress,WebsiteURL,DefaultView,ApplicationUserId,NeighborhoodId,RecommendationTypeId")] Recommendation recommendation)
        {
            if (id != recommendation.RecommendationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recommendation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecommendationExists(recommendation.RecommendationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            RecommendationEditViewModel editRecommendation = new RecommendationEditViewModel(_context);
            return View(editRecommendation);

            //ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhood, "NeighborhoodId", "Name", recommendation.NeighborhoodId);
            //ViewData["RecommendationTypeId"] = new SelectList(_context.RecommendationType, "RecommendationTypeId", "Name", recommendation.RecommendationTypeId);
            //return View(recommendation);
        }

        // GET: Recommendations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendation = await _context.Recommendation
                .Include(r => r.Neighborhood)
                .Include(r => r.RecommendationType)
                .FirstOrDefaultAsync(m => m.RecommendationId == id);
            if (recommendation == null)
            {
                return NotFound();
            }

            return View(recommendation);
        }

        // POST: Recommendations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recommendation = await _context.Recommendation.FindAsync(id);
            _context.Recommendation.Remove(recommendation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecommendationExists(int id)
        {
            return _context.Recommendation.Any(e => e.RecommendationId == id);
        }
    }
}
