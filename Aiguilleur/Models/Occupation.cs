using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aiguilleur.Models
{
    public class Occupation
    {
        public string id_occupation { get; set; }
        public string id_piste { get; set; }
        public string id_vol { get; set; }

        public DateTime debut_occupation { get; set; }
        public DateTime fin_occupation { get; set; }
        
    }
}