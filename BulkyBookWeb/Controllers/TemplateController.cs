using BulkyBook.DataAccess;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BulkyBookWeb.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TemplateController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objectTemplateList = _db.Templates.ToList();
            return View(objectTemplateList);
        }

        //GET 
        public IActionResult Create()
        {
            return View();
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Template obj)
        {
            _db.Templates.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
