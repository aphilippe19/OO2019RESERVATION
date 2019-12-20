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
    public class DEMANDERsController : Controller
    {
        private DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();

        // GET: DEMANDERs
        public ActionResult Index()
        {
            var dEMANDER = db.DEMANDER.Include(d => d.AGENT).Include(d => d.BUREAU);
            return View(dEMANDER.ToList());
        }

        // GET: DEMANDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMANDER dEMANDER = db.DEMANDER.Find(id);
            if (dEMANDER == null)
            {
                return HttpNotFound();
            }
            return View(dEMANDER);
        }

        // GET: DEMANDERs/Create
        public ActionResult Reservation_Salle()
        {
            ReservationSalleViewModel s = new ReservationSalleViewModel();
            if (Session["libelle_rech"] != null)
            {
                s.LIBELLE_BUREAU = Session["libelle_rech"].ToString();
                s.SUPERFICIE_BUREAU = Session["superficie_rech"].ToString();
                s.CODE_BUREAU = Session["cod_rech"].ToString();
            }
            return View(s);
        }
        public ActionResult ObtenirInfosBureau(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt = new DataTable();

            cles.Clear(); valeurs.Clear();
            cles.Add("@CODE_BUREAU"); valeurs.Add(id);
            dt = ad.getDatatable_fromPS("SP_BAC_GET_DETAIL_BUREAU", cles, valeurs); //get
            if (dt.Rows.Count >= 1)
            {
                Session["cod_rech"] = dt.Rows[0]["CODE_BUREAU"].ToString();
                Session["libelle_rech"] = dt.Rows[0]["LIBELLE_BUREAU"].ToString();
                Session["superficie_rech"] = dt.Rows[0]["SUPERFICIE_BUREAU"].ToString();

                return RedirectToAction("Reservation_Salle");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Create()
        {
            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT");
            ViewBag.ID_BUREAU = new SelectList(db.BUREAU, "ID_BUREAU", "LIBELLE_BUREAU");
            return View();
        }

        // POST: DEMANDERs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DEMANDER,ID_BUREAU,DATE_DEBUT,DATE_FIN,OBJET_REUNION,NBRE_PERSON_INVITE,DATE_TRAITEMENT,ID_AGENT")] DEMANDER dEMANDER)
        {
            if (ModelState.IsValid)
            {
                dEMANDER.DATE_EMISSION = DateTime.Now;
                db.DEMANDER.Add(dEMANDER);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT", dEMANDER.ID_AGENT);
            ViewBag.ID_BUREAU = new SelectList(db.BUREAU, "ID_BUREAU", "LIBELLE_BUREAU", dEMANDER.ID_BUREAU);
            return View(dEMANDER);
        }

        // GET: DEMANDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMANDER dEMANDER = db.DEMANDER.Find(id);
            if (dEMANDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT", dEMANDER.ID_AGENT);
            ViewBag.ID_BUREAU = new SelectList(db.BUREAU, "ID_BUREAU", "CODE_BUREAU", dEMANDER.ID_BUREAU);
            return View(dEMANDER);
        }

        // POST: DEMANDERs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DEMANDER,ID_BUREAU,DATE_DEBUT,DATE_FIN,OBJET_REUNION,NBRE_PERSON_INVITE,ID_AGENT")] DEMANDER dEMANDER)
        {
            if (ModelState.IsValid)
            {
                dEMANDER.DATE_EMISSION = DateTime.Now;
                db.Entry(dEMANDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT", dEMANDER.ID_AGENT);
            ViewBag.ID_BUREAU = new SelectList(db.BUREAU, "ID_BUREAU", "CODE_BUREAU", dEMANDER.ID_BUREAU);
            return View(dEMANDER);
        }

        // GET: DEMANDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMANDER dEMANDER = db.DEMANDER.Find(id);
            if (dEMANDER == null)
            {
                return HttpNotFound();
            }
            return View(dEMANDER);
        }

        // POST: DEMANDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEMANDER dEMANDER = db.DEMANDER.Find(id);
            db.DEMANDER.Remove(dEMANDER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Valider_Salle(string id)
        {
            
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            
            cles.Clear(); valeurs.Clear();
            cles.Add("@ID_DEMANDER"); valeurs.Add(id);
            cles.Add("@STATUT_DEMANDER"); valeurs.Add("Validé");
            ad.getDatatable_fromPS("SP_UPDATE_RESERVER", cles, valeurs); //get

            return RedirectToAction("ListTraitSalle", "Traitement");
        }
        public ActionResult MiseAttente_Salle(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();


            cles.Clear(); valeurs.Clear();
            cles.Add("@ID_DEMANDER"); valeurs.Add(id);
            cles.Add("@STATUT_DEMANDER"); valeurs.Add("Mise En Attente");
            ad.getDatatable_fromPS("SP_UPDATE_RESERVER", cles, valeurs); //get

            return RedirectToAction("ListTraitSalle", "Traitement");
        }
        public ActionResult Differer_Salle(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();


            cles.Clear(); valeurs.Clear();
            cles.Add("@ID_DEMANDER"); valeurs.Add(id);
            cles.Add("@STATUT_DEMANDER"); valeurs.Add("Différer");
            ad.getDatatable_fromPS("SP_UPDATE_RESERVER", cles, valeurs); //get

            return RedirectToAction("ListTraitSalle", "Traitement");
        }

        public ActionResult Reporting_bureau()
        {
           
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt = new DataTable();

            cles.Clear(); valeurs.Clear();
            cles.Add("@MATRICULE_AGENT"); valeurs.Add(DBNull.Value);
            dt = ad.getDatatable_fromPS("SP_GET_DEMANDER_ENVOYE", cles, valeurs); //get

            if (dt.Rows.Count >= 1)
            {
                ViewBag.dt = dt;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
