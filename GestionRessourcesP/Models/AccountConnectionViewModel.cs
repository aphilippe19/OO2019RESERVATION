using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionRessourcesP.Models
{
    public class AccountConnectionViewModel
    {
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter your Email")]
        [Display(Name = "Login")]
        [EmailAddress]
        public string LOGIN_AGENT { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string MDP_AGENT { get; set; }

        [Display(Name = "Mémoriser le mot de passe ?")]
        public bool RememberMe { get; set; }
    }
}