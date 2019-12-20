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
    public class AGENTsController : Controller
    {
        private DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();

        // GET: AGENTs
        public ActionResult Index()
        {
            return View(db.AGENT.ToList());
        }

        // GET: AGENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENT aGENT = db.AGENT.Find(id);
            if (aGENT == null)
            {
                return HttpNotFound();
            }
            return View(aGENT);
        }

        // GET: AGENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AGENTs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_AGENT,MATRICULE_AGENT,NOM_AGENT,PRENOMS_AGENT,SERVICE_AGENT,FONCTION_AGENT,DEPARTEMENT_AGENT,MDP_AGENT,LOGIN_AGENT,PROFIL_AGENT")] AGENT aGENT)
        {
            if (ModelState.IsValid)
            {
                db.AGENT.Add(aGENT);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(aGENT);
        }

        // GET: AGENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENT aGENT = db.AGENT.Find(id);
            if (aGENT == null)
            {
                return HttpNotFound();
            }
            return View(aGENT);
        }

        // POST: AGENTs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_AGENT,MATRICULE_AGENT,NOM_AGENT,PRENOMS_AGENT,SERVICE_AGENT,FONCTION_AGENT,DEPARTEMENT_AGENT,MDP_AGENT,LOGIN_AGENT,PROFIL_AGENT")] AGENT aGENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aGENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aGENT);
        }

        // GET: AGENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENT aGENT = db.AGENT.Find(id);
            if (aGENT == null)
            {
                return HttpNotFound();
            }
            return View(aGENT);
        }

        // POST: AGENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AGENT aGENT = db.AGENT.Find(id);
            db.AGENT.Remove(aGENT);
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
