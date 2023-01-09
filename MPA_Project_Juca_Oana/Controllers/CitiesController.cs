using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MPA_Project_Juca_Oana.Data;
using MPA_Project_Juca_Oana.Models;
using MPA_Project_Juca_Oana.Models.ViewModels;

namespace MPA_Project_Juca_Oana.Controllers
{
    public class CitiesController : Controller
    {
        private readonly LibraryContext _context;

        public CitiesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index(int? id, int? stadiumsID)
        {
            var viewModel = new CityIndexData();
           // viewModel.City = await _context.City
           // .Include(i => i.StadiumByCity)
              //  .ThenInclude(i => i.Stadiums)
           // .ThenInclude(i => i.Orders)
           // .ThenInclude(i => i.Customers)
           // .AsNoTracking()
           // .OrderBy(i => i.Name)
           // .ToListAsync();
            if (id != null)
            {
                ViewData["CityID"] = id.Value;
                City cities = viewModel.City.Where(
                i => i.ID == id.Value).Single();
                viewModel.Stadiums = cities.StadiumByCity.Select(s => s.Stadium);
            }
            if (stadiumsID != null)
            {
                ViewData["StadiumsID"] = stadiumsID.Value;
                viewModel.Orders = viewModel.Stadiums.Where(
                x => x.ID == stadiumsID).Single().Orders;
            }
            return View(viewModel);
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.City_1 == null)
            {
                return NotFound();
            }

            var city = await _context.City_1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CityName")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.City_1 == null)
            {
                return NotFound();
            }

            var city = await _context.City_1.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CityName")] City city)
        {
            if (id != city.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.ID))
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
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.City_1 == null)
            {
                return NotFound();
            }

            var city = await _context.City_1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.City_1 == null)
            {
                return Problem("Entity set 'LibraryContext.City_1'  is null.");
            }
            var city = await _context.City_1.FindAsync(id);
            if (city != null)
            {
                _context.City_1.Remove(city);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
          return _context.City_1.Any(e => e.ID == id);
        }
    }
}
