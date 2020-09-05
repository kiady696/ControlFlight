using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aiguilleur.Models
{
    public class Piste
    {
        public string id_piste { get; set; }
        public string id_aeroport { get; set; }
        public string num_piste { get; set; }
        public double longueur { get; set; } //en mètres
        public double temps_degagement { get; set; } //en heures

    }
}