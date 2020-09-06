using Aiguilleur.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aiguilleur.Models
{
    public class Proposition
    {
        public List<VolPiste> listePropositions { get; set; } //ito ilay misy redondances be @ voalohany dia alana ze mredonder : proposer

        public Proposition(List<VolPiste> list)
        {
            listePropositions = list.ToList();
        }
        
        //F° manome Piste tokana ny VolPiste(Vol) iray
        public void getTheseVolPistesOnePiste(DBConnection dbc)
        {
            //Maka ny pistes concernées aloha 
            List<Piste> listePistesConcerned = new List<Piste>();
            var pistesDistincts = this.listePropositions.Select(x => x.id_piste).Distinct().ToList();
            foreach(var p in pistesDistincts)
            {
                listePistesConcerned.Add(new Piste(p));
            }

            //De maka ny Vols concernés koa
            List<Vol> listeVolsConcerned = new List<Vol>();
            var volsDistincts = this.listePropositions.Select(x => x.id_Vol).Distinct().ToList();
            foreach(var v in volsDistincts)
            {
                listeVolsConcerned.Add(new Vol(v));
            }

            //pour chaque piste concernee , getHisOccupationIfExist
            foreach(Piste pc in listePistesConcerned)
            {
                pc.getOccupations(dbc);
            }

            //mcheck amzay hoe mifanipaka ve sa tsia ny listePropIntervalle sy ny pistesOccupationsIntervalles

            //MISY TSY METY NY ALGO AN'ITO FA ATAO AMNY TARATASY TSARA RAALINA

            /*foreach(VolPiste vp in this.listePropositions.ToList())
            {
                foreach(Piste p in listePistesConcerned)
                {
                    
                        foreach(Occupation o in p.tempsMisyAvion)
                        {
                                
                                IntervalleTemps intVP = new IntervalleTemps(vp.dateProbableArrivee, vp.fin_utilisation);
                                System.Diagnostics.Debug.WriteLine("Vp :"+vp.id_Vol+"|" + intVP.debut.ToString() + " - " + intVP.fin.ToString());
                                IntervalleTemps intOcc = new IntervalleTemps(o.debut_occupation, o.fin_occupation);
                                System.Diagnostics.Debug.WriteLine("Occupation :" + intOcc.debut.ToString() + " - " + intOcc.fin.ToString());
                                if (intVP.checkIfCrossWith(intOcc)) //Raha misy occupation aminy dia alao ilay VolPiste
                                {
                                    this.listePropositions.Remove(vp);
                                }

                            
                                
                        }
                    
                }
            }*/

            foreach(Piste p in listePistesConcerned)
            {
                foreach(Occupation o in p.tempsMisyAvion)
                {
                    foreach(VolPiste vp in this.listePropositions.ToList())
                    {
                        if(vp.id_piste == o.id_piste)
                        {
                            IntervalleTemps intVP = new IntervalleTemps(vp.dateProbableArrivee, vp.fin_utilisation);
                            System.Diagnostics.Debug.WriteLine("Vp :" + vp.id_Vol + "|" + intVP.debut.ToString() + " - " + intVP.fin.ToString());
                            IntervalleTemps intOcc = new IntervalleTemps(o.debut_occupation, o.fin_occupation);
                            System.Diagnostics.Debug.WriteLine("Occupation :" + intOcc.debut.ToString() + " - " + intOcc.fin.ToString());
                            if (intVP.checkIfCrossWith(intOcc))
                            {
                                this.listePropositions.Remove(vp);
                            }
                        }
                    }
                }
            }

            //Raha tsisy VolPiste instony mifanaraka amna vol nisy tao de decallena ilay vol
                
        }
        

    }
}