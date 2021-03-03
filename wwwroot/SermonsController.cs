using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CFCprototype.Data;
using CFCprototype.Models;

namespace CFCprototype.wwwroot
{
    public class SermonsController : Controller
    {
        private readonly CFCprototypeContext _context;

        public SermonsController(CFCprototypeContext context)
        {
            _context = context;
        }

        // GET: Sermons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sermon.ToListAsync());
        }

        // GET: Sermons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sermon = await _context.Sermon
                .FirstOrDefaultAsync(m => m.SermonID == id);
            if (sermon == null)
            {
                return NotFound();
            }

            return View(sermon);
        }

        // GET: Sermons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sermons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SermonID,SermonTitle,SermonLink,SermonDate")] Sermon sermon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sermon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sermon);
        }

        // GET: Sermons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sermon = await _context.Sermon.FindAsync(id);
            if (sermon == null)
            {
                return NotFound();
            }
            return View(sermon);
        }

        // POST: Sermons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SermonID,SermonTitle,SermonLink,SermonDate")] Sermon sermon)
        {
            if (id != sermon.SermonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sermon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SermonExists(sermon.SermonID))
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
            return View(sermon);
        }

        // GET: Sermons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sermon = await _context.Sermon
                .FirstOrDefaultAsync(m => m.SermonID == id);
            if (sermon == null)
            {
                return NotFound();
            }

            return View(sermon);
        }

        // POST: Sermons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sermon = await _context.Sermon.FindAsync(id);
            _context.Sermon.Remove(sermon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SermonExists(int id)
        {
            return _context.Sermon.Any(e => e.SermonID == id);
        }
    }
}
