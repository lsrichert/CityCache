using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using final_capstone.Data;
using final_capstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace final_capstone.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NeighborhoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Neighborhoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Neighborhood.ToListAsync());
        }

        // GET: Neighborhoods/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var neighborhood = await _context.Neighborhood
        //        .FirstOrDefaultAsync(m => m.NeighborhoodId == id);
        //    if (neighborhood == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(neighborhood);
        //}

        // GET: Neighborhoods/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Neighborhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NeighborhoodId,Name")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neighborhood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(neighborhood);
        }

        //// GET: Neighborhoods/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var neighborhood = await _context.Neighborhood.FindAsync(id);
        //    if (neighborhood == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(neighborhood);
        //}

        //// POST: Neighborhoods/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("NeighborhoodId,Name")] Neighborhood neighborhood)
        //{
        //    if (id != neighborhood.NeighborhoodId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(neighborhood);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NeighborhoodExists(neighborhood.NeighborhoodId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(neighborhood);
        //}

        // GET: Neighborhoods/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var neighborhood = await _context.Neighborhood
        //            .FirstOrDefaultAsync(m => m.NeighborhoodId == id);
        //        if (neighborhood == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(neighborhood);
        //    }

        //    // POST: Neighborhoods/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var neighborhood = await _context.Neighborhood.FindAsync(id);
        //        _context.Neighborhood.Remove(neighborhood);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool NeighborhoodExists(int id)
        //    {
        //        return _context.Neighborhood.Any(e => e.NeighborhoodId == id);
        //    }
    }
}
