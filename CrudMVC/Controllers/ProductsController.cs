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
    public class ProductsController : Controller
    {
        private string _UsrMsg;
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Products Product { get; set; }

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {
            var myProducts = await _db.Products.ToListAsync();
            return View(myProducts);
        }

        public IActionResult Upsert(int? id)
        {
            Product = new Products();
            if (id == null)
            {
                //Create Action
                return View(Product);
            }
            //Edit Action
            Product = _db.Products.FirstOrDefault(u => u.Id == id); //Searching for a specific product
            if (Product == null) //If there is no product returned
            {
                return NotFound();
            }
            return View(Product); //Return the products that's found
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert() //To handle the Post action
        {
            if (ModelState.IsValid)
            {
                _UsrMsg = "";
                if (Product.Id == 0)
                {
                    //Create Book
                    _db.Products.Add(Product);
                    _UsrMsg = "Add Successful";
                }
                else
                {
                    //Update Book
                    _db.Products.Update(Product);
                    _UsrMsg = "Update Successful";
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Product);
        }

        public IActionResult OnGet()
        {
            return View(Product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            _UsrMsg = "";
            var productFromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (productFromDb == null)
            {
                _UsrMsg = "Error while Deleting";
            }
            _db.Products.Remove(productFromDb);
            await _db.SaveChangesAsync();
            _UsrMsg = "Delete Successful";
            return RedirectToAction("Index");
        }
    }
}
