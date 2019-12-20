using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionRessourcesP.Models
{
    public class ReservationMobilierViewModel
    {
        [Required(ErrorMessage = "Please enter your Code Bnetd")]
        [DisplayName("Code Bnetd")]
        public string CODE_MOBILIER { get; set; }

        [Required(ErrorMessage = "Please enter your Type Equipement")]
        [DisplayName("Type Equipement")]
        public string LIBELLE_MOBILIER { get; set; }

        [Required(ErrorMessage = "Please enter your Marque")]
        [DisplayName("Marque")]
        public string MARQUE_MOBILIER { get; set; }

        [Required(ErrorMessage = "Please enter your Modèle")]
        [DisplayName("Modèle")]
        public string MODELE_MOBILIER { get; set; }

        [Required(ErrorMessage = "Please enter your Numéro de serie")]
        [DisplayName("Numéro Serie ")]
        public string NUMSERIE_MOBILIER { get; set; }

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

        [Required(ErrorMessage = "Please enter your Login")]
        [DisplayName("Login")]
        public string LOGIN_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Profil")]
        [DisplayName("Profil")]
        public string PROFIL_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Département")]
        [DisplayName("Département")]
        public string DEPARTEMENT_AGENT { get; set; }

        [Required(ErrorMessage = "Please enter your Date debut")]
        [DisplayName("Date Début")]
        public Nullable<System.DateTime> DATE_DEBUT { get; set; }

        [Required(ErrorMessage = "Please enter your Date fin")]
        [DisplayName("Date Fin")]
        public Nullable<System.DateTime> DATE_FIN { get; set; }

        [Required(ErrorMessage = "Please enter your Objet")]
        [DisplayName("Objet Réunion")]
        public string OBJET_REUNION { get; set; }

        [Required(ErrorMessage = "Please enter your Date retour")]
        [DisplayName("Date Retour")]
        public Nullable<System.DateTime> DATE_RETOUR { get; set; }

        [Required(ErrorMessage = "Please enter your Motif retour")]
        [DisplayName("Motif Retour")]
        public string MOTIF_RETOUR { get; set; }

        public int ID_MOBILIER { get; set; }
    }
}