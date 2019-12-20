using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionRessourcesP.Models
{
    public class ReservationSalleViewModel
    {
        [DisplayName("Code Bnetd")]
        public int ID_SITE { get; set; }

        [Required(ErrorMessage = "Please enter your code Bnetd")]
        [DisplayName("Code Bnetd")]
        public string CODE_BUREAU { get; set; }

        [Required(ErrorMessage = "Please enter your Libellé Bureau")]
        [DisplayName("Bureau")]
        public string LIBELLE_BUREAU { get; set; }

        [Required(ErrorMessage = "Please enter your Superficie")]
        [DisplayName("Superficie Bureau")]
        public string SUPERFICIE_BUREAU { get; set; }

        [Required(ErrorMessage = "Please enter your Matricule")]
        [DisplayName("Matricule")]
        public string MATRICULE_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Nom")]
        [DisplayName("Nom")]
        public string NOM_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Prenoms")]
        [DisplayName("Prenoms")]
        public string PRENOMS_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Service")]
        [DisplayName("Service")]
        public string SERVICE_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Fonction")]
        [DisplayName("Fonction")]
        public string FONCTION_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Mot de Passe")]
        [DisplayName("Mot de Passe")]
        public string MDP_AGENT { get; set; }

        [RegularExpression(".+\\@.+\\..+", 
            ErrorMessage = "Please enter your Email")]
        [DisplayName("Login")]
        public string LOGIN_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Profil")]
        [DisplayName("Profil")]
        public string PROFIL_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Département")]
        [DisplayName("Département")]
        public string DEPARTEMENT_AGENT { get; set; }

        [DisplayName("Date Début")]
        public Nullable<System.DateTime> DATE_DEBUT { get; set; }

        [DisplayName("Date Fin")]
        public Nullable<System.DateTime> DATE_FIN { get; set; }

        [Required(ErrorMessage = "Please enter your objet")]
        [DisplayName("Objet Réunion")]
        public string OBJET_REUNION { get; set; }

        [Required(ErrorMessage = "Please enter your Personne")]
        [DisplayName("Personne Invité")]
        public string NBRE_PERSON_INVITE { get; set; }

        [Required(ErrorMessage = "Please enter your code")]
        [DisplayName("Code Palier")]
        public string CODE_PALIER { get; set; }

        [Required(ErrorMessage = "Please enter your Libellé")]
        [DisplayName("Palier")]
        public string LIBELLE_PALIER { get; set; }

        [DisplayName("Date Emission")]
        public Nullable<System.DateTime> DATE_EMMISSION { get; set; }

        [DisplayName("Date traitement")]
        public Nullable<System.DateTime> DATE_TRAITEMENT { get; set; }

        [Required(ErrorMessage = "Please enter your Code Site")]
        [DisplayName("Code Site")]
        public string CODE_SITE { get; set; }

        [Required(ErrorMessage = "Please enter your Libellé Site")]
        [DisplayName("Site")]
        public string LIBELLE_SITE { get; set; }

        [Required(ErrorMessage = "Please enter your Superficie Site")]
        [DisplayName("Superficie Site")]
        public string SUPERFICIE_SITE { get; set; }

    }
}