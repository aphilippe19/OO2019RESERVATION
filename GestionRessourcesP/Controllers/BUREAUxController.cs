using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionRessourcesP.Models;

namespace GestionRessourcesP.Controllers
{
    public class BUREAUxController : Controller
    {
        private DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();

        // GET: BUREAUx
        public ActionResult Index()
        {
            var bUREAU = db.BUREAU.Include(b => b.PALIER).Include(b => b.SITE);
            return View(bUREAU.ToList());
        }

        // GET: BUREAUx/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BUREAU bUREAU = db.BUREAU.Find(id);
            if (bUREAU == null)
            {
                return HttpNotFound();
            }
            return View(bUREAU);
        }

        // GET: BUREAUx/Create
        public ActionResult Create()
        {
            ViewBag.ID_PALIER = new SelectList(db.PALIER, "ID_PALIER", "LIBELLE_PALIER");
            ViewBag.ID_SITE = new SelectList(db.SITE, "ID_SITE", "LIBELLE_SITE");
            return View();
        }

        // POST: BUREAUx/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BUREAU,CODE_BUREAU,LIBELLE_BUREAU,SUPERFICIE_BUREAU,ID_PALIER,ID_SITE")] BUREAU bUREAU)
        {
            if (ModelState.IsValid)
            {
                db.BUREAU.Add(bUREAU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PALIER = new SelectList(db.PALIER, "ID_PALIER", "LIBELLE_PALIER", bUREAU.ID_PALIER);
            ViewBag.ID_SITE = new SelectList(db.SITE, "ID_SITE", "LIBELLE_SITE", bUREAU.ID_SITE);
            return View(bUREAU);
        }

        // GET: BUREAUx/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BUREAU bUREAU = db.BUREAU.Find(id);
            if (bUREAU == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PALIER = new SelectList(db.PALIER, "ID_PALIER", "LIBELLE_PALIER", bUREAU.ID_PALIER);
            ViewBag.ID_SITE = new SelectList(db.SITE, "ID_SITE", "LIBELLE_SITE", bUREAU.ID_SITE);
            return View(bUREAU);
        }

        // POST: BUREAUx/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BUREAU,CODE_BUREAU,LIBELLE_BUREAU,SUPERFICIE_BUREAU,ID_PALIER,ID_SITE")] BUREAU bUREAU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bUREAU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PALIER = new SelectList(db.PALIER, "ID_PALIER", "LIBELLE_PALIER", bUREAU.ID_PALIER);
            ViewBag.ID_SITE = new SelectList(db.SITE, "ID_SITE", "LIBELLE_SITE", bUREAU.ID_SITE);
            return View(bUREAU);
        }

        // GET: BUREAUx/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BUREAU bUREAU = db.BUREAU.Find(id);
            if (bUREAU == null)
            {
                return HttpNotFound();
            }
            return View(bUREAU);
        }

        // POST: BUREAUx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BUREAU bUREAU = db.BUREAU.Find(id);
            db.BUREAU.Remove(bUREAU);
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
