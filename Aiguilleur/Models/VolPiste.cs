using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aiguilleur.Models
{
    public class VolPiste : Vol
    {
        public VolPiste(string idvol, string id_piste) //mbola afaka apiana attributs hafa anle vols ra ilaina amn affichage
        {
            this.id_Vol = idvol ?? throw new ArgumentNullException(nameof(idvol));
            this.id_piste = id_piste ?? throw new ArgumentNullException(nameof(id_piste));
        }

        public string id_piste { get; set; }
        
    }
}