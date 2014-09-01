using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MariosPizza.Models;

namespace MariosPizza.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private MenuDbContext db = new MenuDbContext();

        // GET: /Menu/
        [AllowAnonymous]
        public ActionResult Index(string m)
        {
            //var menus = db.Menus.Include(m => m.Category);
            if (m == "dinner")
            {
                var dbFiltered = db.Menus.Where(od => od.Availability == "All" || od.Availability == "Dinner");
                dbFiltered = dbFiltered.OrderBy(s => s.CategoryId);
                ViewBag.typeOfMeal = "Dinner";
                return View(dbFiltered.ToList());
            }
            else if (m == "lunch")
            {
                var dbFiltered = db.Menus.Where(av => av.Availability == "All" || av.Availability == "Lunch");
                dbFiltered = dbFiltered.OrderBy(s => s.CategoryId);
                ViewBag.typeOfMeal = "Lunch";
                return View(dbFiltered.ToList());
            }
            return HttpNotFound();
        }

        // GET: /Menu/Specials
        [AllowAnonymous]
        public ViewResult Specials()
        {
            return View();
        }

        // GET: /Menu/ViewItems/
        public ViewResult ViewItems()
        {
            return View(db.Menus.ToList());
        }
        
        // GET: /Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: /Menu/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.MenuCategorys, "CategoryId", "CategoryName");
            return View();
        }

        // POST: /Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ItemName,Availability,Description,Price,CategoryId,NewItem,Limited")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.MenuCategorys, "CategoryId", "CategoryName", menu.CategoryId);
            return View(menu);
        }

        // GET: /Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.MenuCategorys, "CategoryId", "CategoryName", menu.CategoryId);
            return View(menu);
        }

        // POST: /Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ItemName,Availability,Description,Price,CategoryId,NewItem,Limited")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.MenuCategorys, "CategoryId", "CategoryName", menu.CategoryId);
            return View(menu);
        }

        // GET: /Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: /Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
