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
    public class PALIERsController : Controller
    {
        private DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();

        // GET: PALIERs
        public ActionResult Index()
        {
            return View(db.PALIER.ToList());
        }

        // GET: PALIERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PALIER pALIER = db.PALIER.Find(id);
            if (pALIER == null)
            {
                return HttpNotFound();
            }
            return View(pALIER);
        }

        // GET: PALIERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PALIERs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PALIER,CODE_PALIER,LIBELLE_PALIER")] PALIER pALIER)
        {
            if (ModelState.IsValid)
            {
                db.PALIER.Add(pALIER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pALIER);
        }

        // GET: PALIERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PALIER pALIER = db.PALIER.Find(id);
            if (pALIER == null)
            {
                return HttpNotFound();
            }
            return View(pALIER);
        }

        // POST: PALIERs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PALIER,CODE_PALIER,LIBELLE_PALIER")] PALIER pALIER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pALIER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pALIER);
        }

        // GET: PALIERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PALIER pALIER = db.PALIER.Find(id);
            if (pALIER == null)
            {
                return HttpNotFound();
            }
            return View(pALIER);
        }

        // POST: PALIERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PALIER pALIER = db.PALIER.Find(id);
            db.PALIER.Remove(pALIER);
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
