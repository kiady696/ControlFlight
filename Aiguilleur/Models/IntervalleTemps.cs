using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aiguilleur.Models
{
    public class IntervalleTemps
    {
        public IntervalleTemps(DateTime debut, DateTime fin)
        {
            if(debut.CompareTo(fin) > 0 || fin.CompareTo(debut) < 0 || debut.CompareTo(fin) == 0)
            {
                System.Diagnostics.Debug.WriteLine(debut.ToString()+" - "+fin.ToString());
                throw new Exception("Erreur sur les intervalles de temps");
            }
            else
            {
                this.debut = debut;
                this.fin = fin;
            }
            
        }

        public DateTime debut { get; set; }

        public DateTime fin { get; set; }

        //comparer deux intervalles de temps si elles se coupent 
        public bool checkIfCrossWith(IntervalleTemps toCheck)
        {
            if (this.debut.CompareTo(toCheck.debut) > 0 && this.fin.CompareTo(toCheck.fin) < 0 ) //cas 1: anatinle occupation ilay vol
            {
                System.Diagnostics.Debug.WriteLine("cas 1");
                return true;
                
            }
            else if(this.debut.CompareTo(toCheck.debut) < 0 && this.fin.CompareTo(toCheck.debut) > 0 && this.fin.CompareTo(toCheck.fin) < 0) //cas 2: manomboka alohanle occupation le vol de mfarana pdt occupation 
            {
                System.Diagnostics.Debug.WriteLine("cas 2");
                return true;
            }else if (this.debut.CompareTo(toCheck.debut) > 0 && this.debut.CompareTo(toCheck.fin) <0 && this.fin.CompareTo(toCheck.fin) > 0) //cas 3: manomboka pdt occupation ilay vol de mfarana apres occupation 
            {
                System.Diagnostics.Debug.WriteLine("cas 3");
                return true;
            }else if(this.debut.CompareTo(toCheck.debut) < 0 && this.fin.CompareTo(toCheck.fin) > 0) // cas 4: nanomboka talohan occupation ilay vol de nfarana tany arinan occupation
            {
                System.Diagnostics.Debug.WriteLine("cas 4");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("cas Tsy nifanipaka");
                return false;
            }

            
        }

    }
}