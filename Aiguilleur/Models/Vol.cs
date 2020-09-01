using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Aiguilleur.Models
{
    public class Vol
    {
        
        public string id_Vol { get; set; }

       
        public string id_Aeroport_Depart { get; set; }

       
        public string id_Aeroport_Arrivee { get; set; }

       
        public string id_Avion { get; set; }

        
        public DateTime date_Depart { get; set; }

        
        public double duree { get; set; } //en heure


        public double? decalage { get; set; }

        public virtual Avion avion { get; set; }


    }
}