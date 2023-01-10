using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MPA_Project_Juca_Oana.Data;
using Microsoft.AspNetCore.Authorization;

namespace MPA_Project_Juca_Oana.Controllers
{
    [Authorize(Policy = "SysAdmin")]
    public class CustomersController : Controller
    {
        private readonly LibraryContext _context;
        private string _baseUrl = "http://localhost:58730/api/Customers";
        public CustomersController(LibraryContext context)
        {
            _context = context;
        }

    }
}
