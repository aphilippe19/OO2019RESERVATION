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
    
    public partial class PALIER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PALIER()
        {
            this.BUREAU = new HashSet<BUREAU>();
        }
    
        public int ID_PALIER { get; set; }
        public string CODE_PALIER { get; set; }
        public string LIBELLE_PALIER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BUREAU> BUREAU { get; set; }
    }
}
