using Aiguilleur.Connection;
using Aiguilleur.Utils;
using System;
using System.Collections;
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

        public Proposition()
        {
        }



        // List<VolPiste> resultatsPropositions getThese...( List<VolPiste> listeVolsOrdered , List<Piste> pistsOfTheAeroport , dbc)
        public List<VolPiste> getTheseVolPistesOnePiste(List<VolPiste> listeVol,List<Piste> pistesOfTheAirport,DBConnection dbc)
        {

            //Efa misy degagements tsirairay avy ireo pistesOfTheAirport ireo
            //Maka ny pistes concernées aloha 
            /*List <Piste> listePistesConcerned = new List<Piste>();
            var pistesDistincts = this.listePropositions.Select(x => x.id_piste).Distinct().ToList();
            foreach(var p in pistesDistincts)
            {
                for(int i = 0; i<pisteWithDegagement.Count; i++)
                {
                    if(pisteWithDegagement[i].id_piste == p)
                    {
                        listePistesConcerned.Add(pisteWithDegagement[i]);
                        break;
                    }
                }
                
            }

            listeVol = listeVol.GroupBy(x => x.id_Vol, (key, g) => g.OrderBy(e => e.dateProbableArrivee).First()).ToList();



            //De maka ny Vols concernés koa
            /*List<Vol> listeVolsConcerned = new List<Vol>();
            var volsDistincts = this.listePropositions.Select(x => x.id_Vol).Distinct().ToList();
            foreach(var v in volsDistincts)
            {
                listeVolsConcerned.Add(new Vol(v));
            }*/

           /* //Isaky ny listePropositionRedondant , stockena anaty p.listeOccupation ilay occupations an'ireo listeProposition vao teo de iny no bouclena
            List<Occupation> listeOccupations = new List<Occupation>();
            foreach(VolPiste vpred in this.listePropositions)
            {
                listeOccupations.Add(new Occupation(vpred.id_piste, vpred.id_Vol, vpred.dateProbableArrivee, vpred.fin_utilisation));
            }
            //Apdirina anaty listepistesConcernees[id_piste].tempsMisyAvion ireto occupations ireto
            foreach(Occupation ovp in listeOccupations)
            {
                foreach(Piste pc in listePistesConcerned)
                {
                    if(ovp.id_piste == pc.id_piste)
                    {
                        pc.tempsMisyAvion.Add(ovp);
                    }
                }
            }*/

            /*//Recuperena anaty ListRemoved izay voafafa amzay afaka re-alaina aveo
            List<VolPiste> listRemoved = new List<VolPiste>();

            //Tehirizina anaty listepropCopy ilay listeProp redondant am voalohany
            List<VolPiste> listPropositionRedondantCopy = new List<VolPiste>();
            listPropositionRedondantCopy = this.listePropositions.ToList();



            */

            //mcheck amzay hoe mifanipaka ve sa tsia ny listePropIntervalle sy ny pistesOccupationsIntervalles

            for(int i = 0 ; i < listeVol.Count; i++)  // LE MBOLA TSISY PISTE IREO
            {
                listeVol[i].id_piste = null;
                for(int j = 0; j< pistesOfTheAirport.Count; j++) //reefa miova @ vol manaraka dia miverina mjery ny pistes rehetra indray
                {
                    //eto no set-ena ilay p.Degagement isaky ny VolPiste
                    listeVol[i] = new VolPiste( listeVol[i].id_Vol , listeVol[i].id_piste , listeVol[i].besoin , listeVol[i].dateProbableArrivee , pistesOfTheAirport[j].Degagement);
                    if(Utilitaires.checkPiste(listeVol[i] , pistesOfTheAirport[j])) //raha nety taminy ilay piste
                    {
                        //iny ny id_piste omena azy
                        listeVol[i].id_piste = pistesOfTheAirport[j].id_piste;
                        //Enregistrena anatinle occupation an'iny piste iny fa nalainy izany io piste io @ fotoana nilaivay azy
                        pistesOfTheAirport[j].tempsMisyAvion.Add(new Occupation(pistesOfTheAirport[j].id_piste, listeVol[i].id_Vol, listeVol[i].dateProbableArrivee, (listeVol[i].dateProbableArrivee.AddHours(pistesOfTheAirport[j].Degagement))));
                        break; //rehefa nahazo piste soa amantsara iny vol iray iny dia miova @ vol manaraka
                    }
                }
                if(listeVol[i].id_piste == null) //raha tena tsisy libre ny piste nefa nisy antonina azy
                {
                    listeVol[i].decaller(pistesOfTheAirport);
                    //listeVol[i].id_piste = "PTSYNAHITA";
                }
            }

            return listeVol;




            //MISY TSY METY NY ALGO AN'ITO FA ATAO AMNY TARATASY TSARA RAALINA

            //atao anaty liste occupation aloha ny occupation an'ny this.listProposition 


            /*foreach(Piste p in listePistesConcerned)
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
                                listRemoved.Add(vp);
                            }
                        }
                    }
                }
            }

            //Cas : Raha nisy vp voafafa tanteraka satria occupees daholo ny pistes-any
            // Comparer-na ilay this.listePropositionsRedondantCopy sy ilay this.listePropositions efa voatriée
            //identifiena hoe iza ilay id_vol tsy nisy intsony raha nisy voafafa tanteraka (return Vol[] id_Vol)
            // manao fonction mamerina id_Vol anze ao amle liste ray nefa tsy ao amin'ilay anakray 
            System.Diagnostics.Debug.WriteLine("Id_Vol removed :");     
            var idRemoved = listeVolsConcerned.Where(p => !this.listePropositions.Any(p2 => p2.id_Vol == p.id_Vol)); //iza ny id_vol ao @ listeVolsConcerned fa tsy ao @ listePropositions intsony                                                        //(listPropositionRedondantCopy, this.listePropositions).ToList();
            foreach(Vol s in idRemoved)
            {
                System.Diagnostics.Debug.WriteLine("Id_Vol removed :"+ s.id_Vol);
            }
            if(idRemoved.Count() != 0)
            {
                System.Diagnostics.Debug.WriteLine("Nisy vol tsy naazo piste mitsy");
                //Ato ny mtraiter anle VolPiste(s) voa supprimé(s)
                //Averina alaina ny vp rehetra an'ireo id_vol supprimés ireo
                List<VolPiste> casTsisyPisteLibre = new List<VolPiste>();
                foreach(Vol v in idRemoved)
                {
                    foreach(VolPiste vpc in listPropositionRedondantCopy)
                    {
                        if(v.id_Vol == vpc.id_Vol)
                        {
                            //Recuperer-na izay vp rehetra nisy an'ireo id_Vol voaverina , avao @'ilay this.listePropositionsRedondantCopy
                            casTsisyPisteLibre.Add(vpc);
                        }
                    }
                }

                //Ireo vp voa-recuperées (casTsisyPisteLibre) ireo no averina comparer-na par piste nety halava tamle vp sy par occupations anle piste
                List<VolPiste> diffs = new List<VolPiste>(); //<VolPiste , difference>
                foreach(Piste p in listePistesConcerned)
                {
                    foreach(Occupation o in p.tempsMisyAvion)
                    {
                        foreach(VolPiste vp in casTsisyPisteLibre)
                        {
                            if(vp.id_piste == o.id_piste)
                            {
                                System.Diagnostics.Debug.WriteLine("DATE PROBABLE VP :"+vp.dateProbableArrivee);
                                System.Diagnostics.Debug.WriteLine("Fin Occupation :"+o.fin_occupation);
                                diffs.Add(new VolPiste(vp.id_Vol  ,vp.id_piste , vp.dateProbableArrivee  , p.Degagement , Math.Abs((vp.dateProbableArrivee - o.fin_occupation).TotalHours)));
                            }
                        }
                    }
                }

                //Ze vp manana diff = (vp.dateProb - o.fin_occupation) kely indrindra no add-ena @ this.listPropositions (iray par id_vol)
                diffs = diffs
                    .GroupBy(vp => vp.id_Vol)
                    .Select(grp => grp.OrderBy(vp => vp.diff).First())
                    .ToList();
                

                    

                foreach (VolPiste vp in diffs)
                {
                    //Decallena amn'iny diff kely indrindra iny ilay vp
                    vp.decalage = vp.diff;
                    this.listePropositions.Add(vp);
                }




                //raha tiana ho ze piste voalohany iany ny ho an vol iray
                this.listePropositions = this.listePropositions
                    .GroupBy(vp => vp.id_Vol).FirstOrDefault().ToList();



            }


            // var result = input.GroupBy(x => x.F1, (key, g) => g.OrderBy(e => e.F2).First());

            this.listePropositions = this.listePropositions.GroupBy(x => x.id_Vol, (key, g) => g.OrderBy(e => e.dateProbableArrivee).First()).ToList();




        */}


    }
}