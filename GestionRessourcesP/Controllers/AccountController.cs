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
    public class AccountController : Controller
    {
        // GET: Account      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            @ViewBag.Title = "Bienvenue";
            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            Session.RemoveAll();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult login(AccountConnectionViewModel USER)
        {

            if (!ModelState.IsValid)
            //si l'état des données sont valides alors
            {
                return View(USER);
                //retourne la vue user
            }

            Accesdonnees ad = new Accesdonnees();
            ArrayList cles = new ArrayList();
            ArrayList valeurs = new ArrayList();

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            //Création d'une nouvelle instance de la classe DataTable

            cles.Clear(); valeurs.Clear();
            cles.Add("@LOG"); valeurs.Add(USER.LOGIN_AGENT);
            cles.Add("@MDP"); valeurs.Add(USER.MDP_AGENT);
            dt = ad.getDatatable_fromPS("SP_SEC_LOGIN", cles, valeurs); //get
            if (dt.Rows.Count >= 1)
            {
                Session["nom"] = dt.Rows[0]["NOM_AGENT"].ToString();
                Session["prenom"] = dt.Rows[0]["PRENOMS_AGENT"].ToString();
                Session["profil"] = dt.Rows[0]["PROFIL_AGENT"].ToString();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                USER.MDP_AGENT = "";
                ModelState.AddModelError("", "Tentative de connexion non valide.");
                return View(USER);
            }
        }
    }
}