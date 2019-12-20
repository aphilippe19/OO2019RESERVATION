using GestionRessourcesP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GestionRessourcesP.Controllers
{
    public class TraitementController : Controller
    {
        private DB_RESSOURCESPEntities db= new DB_RESSOURCESPEntities();
        // GET: Traitement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListTraitSalle()
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt0 = new DataTable();

            cles.Clear(); valeurs.Clear();
            cles.Add("MATRICULE_AGENT"); valeurs.Add(DBNull.Value);
            dt0 = ad.getDatatable_fromPS("SP_GET_AGENT_DEMANDER"); //get

            if (dt0.Rows.Count >= 1)
            {
                ViewBag.dt0 = dt0;

                return View();
            }

            else
            {
                return RedirectToAction("Create","DEMANDERs");
            }
        }
          
        public ActionResult ListTraitEquipement()
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt0 = new DataTable();

            cles.Clear(); valeurs.Clear();
            cles.Add("MATRICULE_AGENT"); valeurs.Add(DBNull.Value);
            dt0 = ad.getDatatable_fromPS("SP_GET_AGENT_SOLLICITER"); //get

            if (dt0.Rows.Count >= 1)
            {
                ViewBag.dt0 = dt0;

                return View();
            }

            else
            {
                return RedirectToAction("Create","SOLLICITERs");
            }          
        }
        public ActionResult ListTraitdEquipement()
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt0 = new DataTable();

            cles.Clear(); valeurs.Clear();
            cles.Add("MATRICULE_AGENT"); valeurs.Add(DBNull.Value);
            dt0 = ad.getDatatable_fromPS("SP_GET_AGENT_SOLLICITER"); //get

            if (dt0.Rows.Count >= 1)
            {
                ViewBag.dt0 = dt0;

                return View();
            }

            else
            {
                return RedirectToAction("Create","SOLLICITERs");
            }
            
        }
      /*  public ActionResult TraiterEquipement(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            ReservationMobilierViewModel ba = new ReservationMobilierViewModel();
            try
            {
                cles.Clear(); valeurs.Clear();
                cles.Add("@MATRICULE_AGENT"); valeurs.Add(id);
                dt = ad.getDatatable_fromPS("SP_GET_AGENT_SOLLICITER", cles, valeurs); //get
                if (dt.Rows.Count > 0)
                {
                    ba.DATE_DEBUT = Convert.ToDateTime(dt.Rows[0]["DATE_DEBUT"].ToString());
                    ba.DATE_FIN = Convert.ToDateTime(dt.Rows[0]["DATE_FIN"].ToString());
                    ba.CODE_MOBILIER = dt.Rows[0]["CODE_MOBILIER"].ToString();
                    ba.LIBELLE_MOBILIER = dt.Rows[0]["LIBELLE_MOBILIER"].ToString();
                    ba.MATRICULE_AGENT= dt.Rows[0]["MATRICULE_AGENT"].ToString();
                    ba.NOM_AGENT = dt.Rows[0]["NOM_AGENT"].ToString();
                    ba.PRENOMS_AGENT = dt.Rows[0]["PRENOMS_AGENT"].ToString();
                    ba.OBJET_REUNION = dt.Rows[0]["OBJET_REUNION"].ToString();
                }
                return View(ba);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction("Create");
            }
        }
        */
      /*  public ActionResult ValiderEquipement(int? id)
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
            ViewBag.ID_MOBILIER = new SelectList(db.MOBILIER, "ID_MOBILIER", "CODE_MOBILIER", sOLLICITER.ID_MOBILIER);
            return View(sOLLICITER);
        }
*/
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValiderEquipement([Bind(Include = "ID_SOLLICITER,ID_AGENT,ID_MOBILIER,DATE_DEBUT,DATE_FIN,OBJET_REUNION,PERSON_INVITE,DATE_RETOUR,MOTIF_RETOUR")] SOLLICITER sOLLICITER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOLLICITER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AGENT = new SelectList(db.AGENT, "ID_AGENT", "MATRICULE_AGENT", sOLLICITER.ID_AGENT);
            ViewBag.ID_MOBILIER = new SelectList(db.MOBILIER, "ID_MOBILIER", "CODE_MOBILIER", sOLLICITER.ID_MOBILIER);
            return View(sOLLICITER);
        }
        */
       /* public ActionResult TraiterReservSalle(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            ReservationSalleViewModel rs = new ReservationSalleViewModel();
            try
            {
                cles.Clear(); valeurs.Clear();
                cles.Add("@MATRICULE_AGENT"); valeurs.Add(id);
                dt1 = ad.getDatatable_fromPS("SP_GET_AGENT_DEMANDER", cles, valeurs); //get
                if (dt1.Rows.Count > 0)
                {
                    rs.DATE_DEBUT = Convert.ToDateTime(dt1.Rows[0]["DATE_DEBUT"].ToString());
                    rs.DATE_FIN = Convert.ToDateTime(dt1.Rows[0]["DATE_FIN"].ToString());
                    rs.LIBELLE_BUREAU = dt1.Rows[0]["LIBELLE_BUREAU"].ToString();
                    rs.MATRICULE_AGENT = dt1.Rows[0]["MATRICULE_AGENT"].ToString();
                    rs.NOM_AGENT = dt1.Rows[0]["NOM_AGENT"].ToString();
                    rs.PRENOMS_AGENT = dt1.Rows[0]["PRENOMS_AGENT"].ToString();
                    rs.OBJET_REUNION = dt1.Rows[0]["OBJET_REUNION"].ToString();
                }
                return View(rs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction("ListTraitSalle");
            }
                        
        }
        public ActionResult TraiterReservEquip(string id)
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            ReservationMobilierViewModel ba = new ReservationMobilierViewModel();
            try
            {
                cles.Clear(); valeurs.Clear();
                cles.Add("@MATRICULE_AGENT"); valeurs.Add(id);
                dt = ad.getDatatable_fromPS("SP_GET_AGENT_SOLLICITER", cles, valeurs); //get
                if (dt.Rows.Count > 0)
                {
                    ba.DATE_DEBUT = Convert.ToDateTime(dt.Rows[0]["DATE_DEBUT"].ToString());
                    ba.DATE_FIN = Convert.ToDateTime(dt.Rows[0]["DATE_FIN"].ToString());
                    ba.LIBELLE_MOBILIER = dt.Rows[0]["LIBELLE_MOBILIER"].ToString();
                    ba.MATRICULE_AGENT = dt.Rows[0]["MATRICULE_AGENT"].ToString();
                    ba.NOM_AGENT = dt.Rows[0]["NOM_AGENT"].ToString();
                    ba.PRENOMS_AGENT = dt.Rows[0]["PRENOMS_AGENT"].ToString();
                    ba.OBJET_REUNION = dt.Rows[0]["OBJET_REUNION"].ToString();
                }
                return View(ba);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction("Create");
            }
        }
*/
        }
}
