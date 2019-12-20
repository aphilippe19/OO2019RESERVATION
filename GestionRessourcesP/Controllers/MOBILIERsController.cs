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
    public class MOBILIERsController : Controller
    {
        private DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();

        // GET: MOBILIERs
        public ActionResult Index()
        {
            return View(db.MOBILIER.ToList());
        }

        // GET: MOBILIERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOBILIER mOBILIER = db.MOBILIER.Find(id);
            if (mOBILIER == null)
            {
                return HttpNotFound();
            }
            return View(mOBILIER);
        }

        // GET: MOBILIERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MOBILIERs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MOBILIER,CODE_MOBILIER,LIBELLE_MOBILIER,MARQUE_MOBILIER,MODELE_MOBILIER,NUMSERIE_MOBILIER")] MOBILIER mOBILIER)
        {
            if (ModelState.IsValid)
            {
                db.MOBILIER.Add(mOBILIER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mOBILIER);
        }

        // GET: MOBILIERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOBILIER mOBILIER = db.MOBILIER.Find(id);
            if (mOBILIER == null)
            {
                return HttpNotFound();
            }
            return View(mOBILIER);
        }

        // POST: MOBILIERs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MOBILIER,CODE_MOBILIER,LIBELLE_MOBILIER,MARQUE_MOBILIER,MODELE_MOBILIER,NUMSERIE_MOBILIER")] MOBILIER mOBILIER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOBILIER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mOBILIER);
        }

        // GET: MOBILIERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOBILIER mOBILIER = db.MOBILIER.Find(id);
            if (mOBILIER == null)
            {
                return HttpNotFound();
            }
            return View(mOBILIER);
        }

        // POST: MOBILIERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOBILIER mOBILIER = db.MOBILIER.Find(id);
            db.MOBILIER.Remove(mOBILIER);
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
