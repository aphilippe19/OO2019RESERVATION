//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionRessourcesP.Models
{
    using System;
    
    public partial class SP_GET_SOLLICITER_ENVOYE_Result
    {
        public int ID_MOBILIER { get; set; }
        public string CODE_MOBILIER { get; set; }
        public string LIBELLE_MOBILIER { get; set; }
        public string MARQUE_MOBILIER { get; set; }
        public string MODELE_MOBILIER { get; set; }
        public string NUMSERIE_MOBILIER { get; set; }
        public int ID_AGENT { get; set; }
        public string MATRICULE_AGENT { get; set; }
        public string NOM_AGENT { get; set; }
        public string PRENOMS_AGENT { get; set; }
        public string SERVICE_AGENT { get; set; }
        public string FONCTION_AGENT { get; set; }
        public string DEPARTEMENT_AGENT { get; set; }
        public string MDP_AGENT { get; set; }
        public string LOGIN_AGENT { get; set; }
        public string PROFIL_AGENT { get; set; }
        public int ID_SOLLICITER { get; set; }
        public int ID_AGENT1 { get; set; }
        public int ID_MOBILIER1 { get; set; }
        public Nullable<System.DateTime> DATE_DEBUT { get; set; }
        public Nullable<System.DateTime> DATE_FIN { get; set; }
        public string OBJET_REUNION { get; set; }
        public Nullable<System.DateTime> DATE_RETOUR { get; set; }
        public string MOTIF_RETOUR { get; set; }
        public string STATUT_SOLLICITER { get; set; }
        public Nullable<System.DateTime> DATE_EMISSION { get; set; }
        public Nullable<System.DateTime> DATE_TRAITEMENT { get; set; }
        public string STATUT_REPORT { get; set; }
    }
}
