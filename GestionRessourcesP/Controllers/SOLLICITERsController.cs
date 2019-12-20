using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionRessourcesP.Models;
using System.Collections;

namespace GestionRessourcesP.Controllers
{
    public class SOLLICITERsController : Controller
    {
        private DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();

        // GET: SOLLICITERs
        public ActionResult Index()
        {
            var sOLLICITER = db.SOLLICITER.Include(s => s.AGENT).Include(s => s.MOBILIER);
            return View(sOLLICITER.ToList());
        }

        // GET: SOLLICITERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLLICITER sOLLICITER = db.SOLLICITER.Find(id);
            if (sOLLICITER == null)
            {
                return HttpNotFound();
            }
            return View(sOLLICITER);
        }

        // GET: SOLLICITERs/Create
        public ActionResult Create()
        {
            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT");
            ViewBag.ID_MOBILIER = new SelectList(db.MOBILIER, "ID_MOBILIER", "LIBELLE_MOBILIER");
            return View();
        }

        // POST: SOLLICITERs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SOLLICITER,ID_AGENT,ID_MOBILIER,DATE_DEBUT,DATE_FIN,OBJET_REUNION,PERSON_INVITE,DATE_RETOUR,MOTIF_RETOUR")] SOLLICITER sOLLICITER)
        {
            if (ModelState.IsValid)
            {
                sOLLICITER.DATE_EMISSION = DateTime.Now;
                db.SOLLICITER.Add(sOLLICITER);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT", sOLLICITER.ID_AGENT);
            ViewBag.ID_MOBILIER = new SelectList(db.MOBILIER, "ID_MOBILIER", "LIBELLE_MOBILIER", sOLLICITER.ID_MOBILIER);
            return View(sOLLICITER);
        }

        // GET: SOLLICITERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLLICITER sOLLICITER = db.SOLLICITER.Find(id);
            if (sOLLICITER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT", sOLLICITER.ID_AGENT);
            ViewBag.ID_MOBILIER = new SelectList(db.MOBILIER, "ID_MOBILIER", "LIBELLE_MOBILIER", sOLLICITER.ID_MOBILIER);
            return View(sOLLICITER);
        }

        // POST: SOLLICITERs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SOLLICITER,ID_AGENT,ID_MOBILIER,DATE_DEBUT,DATE_FIN,OBJET_REUNION,PERSON_INVITE,DATE_RETOUR,MOTIF_RETOUR")] SOLLICITER sOLLICITER)
        {
            if (ModelState.IsValid)
            {
                sOLLICITER.DATE_EMISSION = DateTime.Now;
                db.Entry(sOLLICITER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT", sOLLICITER.ID_AGENT);
            ViewBag.ID_MOBILIER = new SelectList(db.MOBILIER, "ID_MOBILIER", "LIBELLE_MOBILIER", sOLLICITER.ID_MOBILIER);
            return View(sOLLICITER);
        }

        // GET: SOLLICITERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLLICITER sOLLICITER = db.SOLLICITER.Find(id);
            if (sOLLICITER == null)
            {
                return HttpNotFound();
            }
            return View(sOLLICITER);
        }

        // POST: SOLLICITERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLLICITER sOLLICITER = db.SOLLICITER.Find(id);
            db.SOLLICITER.Remove(sOLLICITER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Valider_Equip(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();


            cles.Clear(); valeurs.Clear();
            cles.Add("@ID_SOLLICITER"); valeurs.Add(id);
            cles.Add("@STATUT_SOLLICITER"); valeurs.Add("Validé");
            ad.getDatatable_fromPS("SP_UPDATE_SOLLICITER", cles, valeurs); //get

            return RedirectToAction("ListTraitEquipement", "Traitement");
        }
        public ActionResult MiseAttente_Equip(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();


            cles.Clear(); valeurs.Clear();
            cles.Add("@ID_SOLLICITER"); valeurs.Add(id);
            cles.Add("@STATUT_SOLLICITER"); valeurs.Add("Mise En Attente");
            ad.getDatatable_fromPS("SP_UPDATE_SOLLICITER", cles, valeurs); //get

            return RedirectToAction("ListTraitEquipement", "Traitement");
        }
        public ActionResult Differer_Equip(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();


            cles.Clear(); valeurs.Clear();
            cles.Add("@ID_SOLLICITER"); valeurs.Add(id);
            cles.Add("@STATUT_SOLLICITER"); valeurs.Add("Différer");
            ad.getDatatable_fromPS("SP_UPDATE_SOLLICITER", cles, valeurs); //get

            return RedirectToAction("ListTraitEquipement", "Traitement");
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
