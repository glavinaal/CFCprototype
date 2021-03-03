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
    public class PrayerRequestsController : Controller
    {
        private readonly CFCprototypeContext _context;

        public PrayerRequestsController(CFCprototypeContext context)
        {
            _context = context;
        }

        // GET: PrayerRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrayerRequest.ToListAsync());
        }

        // GET: PrayerRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayerRequest = await _context.PrayerRequest
                .FirstOrDefaultAsync(m => m.PrayerRequestID == id);
            if (prayerRequest == null)
            {
                return NotFound();
            }

            return View(prayerRequest);
        }

        // GET: PrayerRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrayerRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrayerRequestID,RequestSubject,RequestBody,RequestDate")] PrayerRequest prayerRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prayerRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prayerRequest);
        }

        // GET: PrayerRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayerRequest = await _context.PrayerRequest.FindAsync(id);
            if (prayerRequest == null)
            {
                return NotFound();
            }
            return View(prayerRequest);
        }

        // POST: PrayerRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrayerRequestID,RequestSubject,RequestBody,RequestDate")] PrayerRequest prayerRequest)
        {
            if (id != prayerRequest.PrayerRequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayerRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerRequestExists(prayerRequest.PrayerRequestID))
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
            return View(prayerRequest);
        }

        // GET: PrayerRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayerRequest = await _context.PrayerRequest
                .FirstOrDefaultAsync(m => m.PrayerRequestID == id);
            if (prayerRequest == null)
            {
                return NotFound();
            }

            return View(prayerRequest);
        }

        // POST: PrayerRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prayerRequest = await _context.PrayerRequest.FindAsync(id);
            _context.PrayerRequest.Remove(prayerRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrayerRequestExists(int id)
        {
            return _context.PrayerRequest.Any(e => e.PrayerRequestID == id);
        }
    }
}
