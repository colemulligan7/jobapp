using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jobapp.Data;
using jobapp.Models;
using Microsoft.Data.SqlClient;

namespace jobapp.Controllers
{
    public class PairsController : Controller
    {
        private readonly jobappContext _context;

        public PairsController(jobappContext context)
        {
            _context = context;
        }

        // GET: Pairs
        public async Task<IActionResult> Index(string? error)
        {
            if(error != null)
            {
                ViewBag.ErrorMessage = error;
            }
            var pairQuery = from o in _context.Pairs join ky in _context.Key on o.key_id equals ky.Id join t in _context.Vehicle on o.vehicle_id equals t.Id select new QueryResults { Value = ky.Name, Text = t.year + " " + t.make + " " + t.model, Id = o.Id };
            return View(pairQuery.ToList());
        }

        // GET: Pairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pairs = await _context.Pairs
                .Include(p => p.Key)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pairs == null)
            {
                return NotFound();
            }

            return View(pairs);
        }

        // GET: Pairs/Create
        public IActionResult Create()
        {
            var keyQuery = from p in _context.Key select new { Value = p.Id, Text = p.Name + " - " + p.Desc };
            var vehicleQuery = from p in _context.Vehicle select new { Value = p.Id, Text = p.year + " " + p.make + " " + p.model };
            ViewData["key"] = new SelectList(keyQuery, "Value", "Text");
            ViewData["vehicle"] = new SelectList(vehicleQuery, "Value", "Text");
            return View();
        }

        // POST: Pairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,key_id,vehicle_id")] Pairs pairs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pairs);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    return RedirectToAction(nameof(Index), null,new { error = e.InnerException.Message.ToString() });
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["key_id"] = new SelectList(_context.Key, "Id", "Id", pairs.key_id);
            ViewData["vehicle_id"] = new SelectList(_context.Vehicle, "Id", "Id", pairs.vehicle_id);
            return View(pairs);
        }

        // GET: Pairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyQuery = from p in _context.Key select new { Value = p.Id, Text = p.Name + " - " + p.Desc };
            var vehicleQuery = from p in _context.Vehicle select new { Value = p.Id, Text = p.year + " " + p.make + " " + p.model };
            ViewData["key"] = new SelectList(keyQuery, "Value", "Text");
            ViewData["vehicle"] = new SelectList(vehicleQuery, "Value", "Text");
            var pairs = await _context.Pairs.FindAsync(id);
            if (pairs == null)
            {
                return NotFound();
            }
            ViewData["key_id"] = new SelectList(_context.Key, "Id", "Id", pairs.key_id);
            ViewData["vehicle_id"] = new SelectList(_context.Vehicle, "Id", "Id", pairs.vehicle_id);
            return View(pairs);
        }

        // POST: Pairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,key_id,vehicle_id")] Pairs pairs)
        {
            if (id != pairs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pairs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PairsExists(pairs.Id))
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
            ViewData["key_id"] = new SelectList(_context.Key, "Id", "Id", pairs.key_id);
            ViewData["vehicle_id"] = new SelectList(_context.Vehicle, "Id", "Id", pairs.vehicle_id);
            return View(pairs);
        }

        // GET: Pairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pairs = await _context.Pairs
                .Include(p => p.Key)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pairs == null)
            {
                return NotFound();
            }

            return View(pairs);
        }

        // POST: Pairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pairs = await _context.Pairs.FindAsync(id);
            _context.Pairs.Remove(pairs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PairsExists(int id)
        {
            return _context.Pairs.Any(e => e.Id == id);
        }
    }
}
