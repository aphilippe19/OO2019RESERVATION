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
    using System.Collections.Generic;
    
    public partial class AGENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AGENT()
        {
            this.DEMANDER = new HashSet<DEMANDER>();
            this.SOLLICITER = new HashSet<SOLLICITER>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEMANDER> DEMANDER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLLICITER> SOLLICITER { get; set; }
    }
}
