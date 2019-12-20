using GestionRessourcesP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionRessourcesP.Controllers
{
    public class ParametrageReservationsalleController : Controller
    {
        private DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();
        // GET: ParametrageReservationsalle
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RechercheBureaux()
        {
            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            cles.Clear(); valeurs.Clear();
            cles.Add("@CODE_BUREAU"); valeurs.Add(DBNull.Value);
            dt = ad.getDatatable_fromPS("SP_BAC_GET_DETAIL_BUREAU", cles, valeurs); //get

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
    } }