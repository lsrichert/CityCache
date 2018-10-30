using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using final_capstone.Data;
using final_capstone.Models;

namespace final_capstone.Controllers
{
    public class RecommendationTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecommendationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecommendationTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecommendationType.ToListAsync());
        }

        // GET: RecommendationTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendationType = await _context.RecommendationType
                .FirstOrDefaultAsync(m => m.RecommendationTypeId == id);
            if (recommendationType == null)
            {
                return NotFound();
            }

            return View(recommendationType);
        }

        // GET: RecommendationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecommendationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecommendationTypeId,Name")] RecommendationType recommendationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recommendationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recommendationType);
        }

        // GET: RecommendationTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendationType = await _context.RecommendationType.FindAsync(id);
            if (recommendationType == null)
            {
                return NotFound();
            }
            return View(recommendationType);
        }

        // POST: RecommendationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecommendationTypeId,Name")] RecommendationType recommendationType)
        {
            if (id != recommendationType.RecommendationTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recommendationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecommendationTypeExists(recommendationType.RecommendationTypeId))
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
            return View(recommendationType);
        }

        // GET: RecommendationTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recommendationType = await _context.RecommendationType
                .FirstOrDefaultAsync(m => m.RecommendationTypeId == id);
            if (recommendationType == null)
            {
                return NotFound();
            }

            return View(recommendationType);
        }

        // POST: RecommendationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recommendationType = await _context.RecommendationType.FindAsync(id);
            _context.RecommendationType.Remove(recommendationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecommendationTypeExists(int id)
        {
            return _context.RecommendationType.Any(e => e.RecommendationTypeId == id);
        }
    }
}
