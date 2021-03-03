using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CFCprototype.Data;
using CFCprototype.Models;

namespace CFCprototype.Controllers
{
    public class MembersClassifiedsController : Controller
    {
        private readonly CFCprototypeContext _context;

        public MembersClassifiedsController(CFCprototypeContext context)
        {
            _context = context;
        }

        // GET: MembersClassifieds
        public async Task<IActionResult> Index()
        {
            return View(await _context.MembersClassifieds.ToListAsync());
        }

        // GET: MembersClassifieds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membersClassifieds = await _context.MembersClassifieds
                .FirstOrDefaultAsync(m => m.MembersClassifiedsID == id);
            if (membersClassifieds == null)
            {
                return NotFound();
            }

            return View(membersClassifieds);
        }

        // GET: MembersClassifieds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembersClassifieds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembersClassifiedsID,ClassifiedTitle,ClassifiedBody,PostDate,PostDuration")] MembersClassifieds membersClassifieds)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membersClassifieds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membersClassifieds);
        }

        // GET: MembersClassifieds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membersClassifieds = await _context.MembersClassifieds.FindAsync(id);
            if (membersClassifieds == null)
            {
                return NotFound();
            }
            return View(membersClassifieds);
        }

        // POST: MembersClassifieds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembersClassifiedsID,ClassifiedTitle,ClassifiedBody,PostDate,PostDuration")] MembersClassifieds membersClassifieds)
        {
            if (id != membersClassifieds.MembersClassifiedsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membersClassifieds);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersClassifiedsExists(membersClassifieds.MembersClassifiedsID))
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
            return View(membersClassifieds);
        }

        // GET: MembersClassifieds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membersClassifieds = await _context.MembersClassifieds
                .FirstOrDefaultAsync(m => m.MembersClassifiedsID == id);
            if (membersClassifieds == null)
            {
                return NotFound();
            }

            return View(membersClassifieds);
        }

        // POST: MembersClassifieds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membersClassifieds = await _context.MembersClassifieds.FindAsync(id);
            _context.MembersClassifieds.Remove(membersClassifieds);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersClassifiedsExists(int id)
        {
            return _context.MembersClassifieds.Any(e => e.MembersClassifiedsID == id);
        }
    }
}
