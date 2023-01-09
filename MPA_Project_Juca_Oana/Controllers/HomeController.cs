using Microsoft.AspNetCore.Mvc;
using MPA_Project_Juca_Oana.Models;
using System.Diagnostics;
using MPA_Project_Juca_Oana.Models.ViewModels;
using MPA_Project_Juca_Oana.Data;
using Microsoft.EntityFrameworkCore;

namespace MPA_Project_Juca_Oana.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;

       // public HomeController(ILogger<HomeController> logger)
       // {
         //   _logger = logger;
        //}
        private readonly LibraryContext _context;
        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
            from order in _context.Orders
            group order by order.OrderDate into dateGroup
            select new OrderGroup()
            {
                OrderDate = dateGroup.Key,
                StadiumsCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}