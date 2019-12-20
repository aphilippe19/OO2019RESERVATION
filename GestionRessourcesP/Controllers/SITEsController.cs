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
    public class SITEsController : Controller
    {
        private DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();

        // GET: SITEs
        public ActionResult Index()
        {
            return View(db.SITE.ToList());
        }

        // GET: SITEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SITE sITE = db.SITE.Find(id);
            if (sITE == null)
            {
                return HttpNotFound();
            }
            return View(sITE);
        }

        // GET: SITEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SITEs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SITE,CODE_SITE,LIBELLE_SITE,SUPERFICIE_SITE")] SITE sITE)
        {
            if (ModelState.IsValid)
            {
                db.SITE.Add(sITE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sITE);
        }

        // GET: SITEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SITE sITE = db.SITE.Find(id);
            if (sITE == null)
            {
                return HttpNotFound();
            }
            return View(sITE);
        }

        // POST: SITEs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SITE,CODE_SITE,LIBELLE_SITE,SUPERFICIE_SITE")] SITE sITE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sITE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sITE);
        }

        // GET: SITEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SITE sITE = db.SITE.Find(id);
            if (sITE == null)
            {
                return HttpNotFound();
            }
            return View(sITE);
        }

        // POST: SITEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SITE sITE = db.SITE.Find(id);
            db.SITE.Remove(sITE);
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
