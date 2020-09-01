using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Aiguilleur.Models
{
    public class Modele
    {
        [ScaffoldColumn(false)]
        public string idModele { get; set; }

        [Required]
        public string designation_modele { get; set; }

        [Required]
        public double besoinDecollage { get; set; }

        [Required]
        public double besoinArrivee { get; set; }

        [Required]
        public double longueurAvion { get; set; }

    }
}