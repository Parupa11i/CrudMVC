using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Orders Orders { get; set; }

        public OrdersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Orders.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var orderFromDb = await _db.Orders.FirstOrDefaultAsync(u => u.Id == id);
            if (orderFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Orders.Remove(orderFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion

    }
}
