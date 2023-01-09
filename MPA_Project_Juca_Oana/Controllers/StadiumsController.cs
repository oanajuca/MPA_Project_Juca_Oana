using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MPA_Project_Juca_Oana.Data;
using MPA_Project_Juca_Oana.Models;

namespace MPA_Project_Juca_Oana.Controllers
{
    public class StadiumsController : Controller
    {
        private readonly LibraryContext _context;

        public StadiumsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Stadiums
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var stadiums = from b in _context.Stadiums
                        join a in _context.Teams on b.TeamID equals a.ID
                        select new Stadiums
                        {
                            ID = b.ID,
                            Name = b.Name,
                            Price = b.Price,
                            Teams = a
                        };


            if (!String.IsNullOrEmpty(searchString))
            {
                stadiums = stadiums.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    stadiums = stadiums.OrderByDescending(b => b.Name);
                    break;
                case "Price":
                    stadiums = stadiums.OrderBy(b => b.Price);
                    break;
                case "price_desc":
                    stadiums = stadiums.OrderByDescending(b => b.Price);
                    break;
                default:
                    stadiums = stadiums.OrderBy(b => b.Name);
                    break;
            }
            int pageSize = 2;
            return View(await PaginatedList<Stadiums>.CreateAsync(stadiums, pageNumber ?? 1, pageSize));
        }


        // GET: Stadiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }
            var stadiums = await _context.Stadiums
                .Include(s => s.Orders)
                    .ThenInclude(e => e.Customers)
                    .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stadiums == null)
            {
                return NotFound();
            }

            return View(stadiums);
        }

        // GET: Stadiums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stadiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,TeamsID")] Stadiums stadiums)
        {
            try
            {
            if (ModelState.IsValid)
            {
                _context.Add(stadiums);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            }
            catch (DbUpdateException /* ex*/)
            {

                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists ");
            }
            return View(stadiums);
        }

        // GET: Stadiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }

            var stadiums = await _context.Stadiums.FindAsync(id);
            if (stadiums == null)
            {
                return NotFound();
            }
            return View(stadiums);
        }

        // POST: Stadiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var stadiumToUpdate = await _context.Stadiums.FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Stadiums>(stadiumToUpdate,
  "",
  s => s.Teams, s => s.Name, s => s.Price))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists");
                }
            }
            return View(stadiumToUpdate);
        }

        // GET: Stadiums/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }

            var stadiums = await _context.Stadiums
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stadiums == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
 {
 ViewData["ErrorMessage"] =
 "Delete failed. Try again";
 }
            return View(stadiums);
        }

        // POST: Stadiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stadiums == null)
            {
                return Problem("Entity set 'LibraryContext.Stadiums'  is null.");
            }
            var stadiums = await _context.Stadiums.FindAsync(id);
            if (stadiums == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {

                _context.Stadiums.Remove(stadiums);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {

                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }

        private bool StadiumsExists(int id)
        {
          return _context.Stadiums.Any(e => e.ID == id);
        }
    }
}
