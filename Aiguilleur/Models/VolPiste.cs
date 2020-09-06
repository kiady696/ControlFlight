using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aiguilleur.Models
{
    public class VolPiste : Vol
    {
        public VolPiste(string idvol, string id_piste,DateTime dateProbable,double tempDegagement) : base(idvol) //mbola afaka apiana attributs hafa anle vols ra ilaina amn affichage
        {

            this.id_piste = id_piste ?? throw new ArgumentNullException(nameof(id_piste));
            this.dateProbableArrivee = dateProbable ;
            this.duree_occupation = tempDegagement;
            this.fin_utilisation = dateProbableArrivee.AddHours(duree_occupation);
        }

        public string id_piste { get; set; }

        public DateTime fin_utilisation { get; set; }

        public double duree_occupation { get; set; }

        
    }
}