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
            if (ModelState.IsValid)
            {
                _db.Templates.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = obj.TemplateName + " is added successfully . ";
                return RedirectToAction("Index");

            }
            return View(obj);
        }



        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id.Value==0)
            {
                return NotFound();
            }
            var TemplateFromDb = _db.Templates.Find(id);
            if(TemplateFromDb==null)
            {
                return NotFound();
            }

            return View(TemplateFromDb);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Template obj)
        {
            if(ModelState.IsValid)
            {
                _db.Templates.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = obj.TemplateName + " is editted successfully . ";
                return RedirectToAction("Index");

            }
            return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var TemplateFromDb = _db.Templates.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (TemplateFromDb == null)
            {
                return NotFound();
            }

            return View(TemplateFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Templates.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Templates.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Template deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
