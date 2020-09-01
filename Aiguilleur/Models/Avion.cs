using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Aiguilleur.Models
{
    public class Avion
    {
        [ScaffoldColumn(false)]
        public string idAvion { get; set; }

        [Required]
        public string idModele { get; set; }

        [Required]
        public string nomAvion { get; set; }


        public virtual Modele modele { get; set; }


    }
}