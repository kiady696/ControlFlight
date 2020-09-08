using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aiguilleur.Models
{
    public class Occupation
    {
        public Occupation()
        {
        }

        public Occupation( string id_piste, string id_vol, DateTime debut_occupation, DateTime fin_occupation)
        {
            //this.id_occupation = id_occupation ?? throw new ArgumentNullException(nameof(id_occupation));
            this.id_piste = id_piste ?? throw new ArgumentNullException(nameof(id_piste));
            this.id_vol = id_vol ?? throw new ArgumentNullException(nameof(id_vol));
            this.debut_occupation = debut_occupation;
            this.fin_occupation = fin_occupation;
        }

        public string id_occupation { get; set; }
        public string id_piste { get; set; }
        public string id_vol { get; set; }

        public DateTime debut_occupation { get; set; }
        public DateTime fin_occupation { get; set; }
        
    }
}