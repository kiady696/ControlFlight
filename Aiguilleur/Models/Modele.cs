using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Aiguilleur.Models
{
    public class Modele : Avion
    {
        
        public string id_Modele { get; set; }

        
        public string designation_modele { get; set; }

        
        public double besoin_Decollage { get; set; }

        
        public double besoin_Atterrissage { get; set; }

        
        public double longueur_modele { get; set; }

    }
}