using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithLogin.Data;
using WebAppWithLogin.Models;

namespace WebAppWithLogin.Controllers
{
    public class ElectronicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElectronicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Electronics
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Electronics.ToListAsync());
        }

        // GET: Electronics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electronics = await _context.Electronics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (electronics == null)
            {
                return NotFound();
            }

            return View(electronics);
        }

        // GET: Electronics/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Electronics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Quantity,InStock")] Electronics electronics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electronics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(electronics);
        }

        // GET: Electronics/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electronics = await _context.Electronics.FindAsync(id);
            if (electronics == null)
            {
                return NotFound();
            }
            return View(electronics);
        }

        // POST: Electronics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Quantity,InStock")] Electronics electronics)
        {
            if (id != electronics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electronics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectronicsExists(electronics.Id))
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
            return View(electronics);
        }

        // GET: Electronics/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electronics = await _context.Electronics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (electronics == null)
            {
                return NotFound();
            }

            return View(electronics);
        }

        // POST: Electronics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var electronics = await _context.Electronics.FindAsync(id);
            if (electronics != null)
            {
                _context.Electronics.Remove(electronics);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectronicsExists(int id)
        {
            return _context.Electronics.Any(e => e.Id == id);
        }
    }
}
