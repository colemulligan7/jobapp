using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jobapp.Data;
using jobapp.Models;

namespace jobapp.Controllers
{
    public class TechsController : Controller
    {
        private readonly jobappContext _context;

        public TechsController(jobappContext context)
        {
            _context = context;
        }

        // GET: Techs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tech.ToListAsync());
        }

        // GET: Techs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tech == null)
            {
                return NotFound();
            }

            return View(tech);
        }

        // GET: Techs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Techs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,first_name,last_name,Vehicle")] Tech tech)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tech);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tech);
        }

        // GET: Techs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech.FindAsync(id);
            if (tech == null)
            {
                return NotFound();
            }
            return View(tech);
        }

        // POST: Techs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,first_name,last_name,Vehicle")] Tech tech)
        {
            if (id != tech.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tech);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechExists(tech.Id))
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
            return View(tech);
        }

        // GET: Techs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tech == null)
            {
                return NotFound();
            }

            return View(tech);
        }

        // POST: Techs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tech = await _context.Tech.FindAsync(id);
            _context.Tech.Remove(tech);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechExists(int id)
        {
            return _context.Tech.Any(e => e.Id == id);
        }
    }
}
