using Aiguilleur.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aiguilleur.Models
{
    public class VolPiste : Vol
    {
        public VolPiste(string idvol, string id_piste,double besoinn,DateTime dateProbable,double tempDegagement) : base(idvol) //mbola afaka apiana attributs hafa anle vols ra ilaina amn affichage
        {

            this.id_piste = id_piste ;
            this.dateProbableArrivee = dateProbable ;
            this.besoin = besoinn;
            this.duree_occupation = tempDegagement;
            this.fin_utilisation = dateProbableArrivee.AddHours(duree_occupation);
        }

        public VolPiste(string idvol, string id_piste, DateTime dateProbable, double tempDegagement) : base(idvol) //mbola afaka apiana attributs hafa anle vols ra ilaina amn affichage
        {

            this.id_piste = id_piste;
            this.dateProbableArrivee = dateProbable;
            this.duree_occupation = tempDegagement;
            this.fin_utilisation = dateProbableArrivee.AddHours(duree_occupation);
        }

        public VolPiste(string idvol, string id_piste, DateTime dateProbable, double tempDegagement, double difff) : base(idvol) //Ho anle VolPiste tsy naazo piste ito constr ito
        {
            this.id_piste = id_piste ?? throw new ArgumentNullException(nameof(id_piste));
            this.diff = difff;
            this.dateProbableArrivee = dateProbable;
            this.duree_occupation = tempDegagement;
            this.fin_utilisation = dateProbableArrivee.AddHours(duree_occupation);
        }


        public void decaller(List<Piste> listPConcerned)
        {
            double min = 50000;
            int temp = 0;
            Occupation Otemp = new Occupation();
            System.Diagnostics.Debug.WriteLine("la premiere piste re-bouclée :" + listPConcerned[0].longueur);
            for (int i = 0; i < listPConcerned.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("la " + i + "ème piste re-bouclée :" + listPConcerned[i].longueur);
                if (!Utilitaires.checkPisteLongueur(this, listPConcerned[i]))
                {
                    continue; //tsy mety aminy ilay piste eeh , miova piste
                }else if (listPConcerned[i].tempsMisyAvion == null) //raha tsy bola nisy nampiasa ilay piste
                {
                    if(!Utilitaires.checkPisteLongueur(this, listPConcerned[i])) //raha tsy antonina azy ihany anefa ilay piste de miova piste
                    {
                        continue;
                    }
                    else //raha antonina azy kosa ilay piste tsy mbola nisy nampiasa
                    {
                        this.id_piste = listPConcerned[i].id_piste;
                        Otemp = new Occupation(listPConcerned[i].id_piste, this.id_Vol, this.dateProbableArrivee, this.dateProbableArrivee.AddHours(listPConcerned[i].Degagement));
                        temp = i;
                        break;
                    }
                }else //Raha sady antonina ilay piste no efa nisy nampiasa tany aloha
                {
                    //Alaina ny occupation farany anatinle tempsMisyAvion anle piste concerned
                    Occupation farany = listPConcerned[i].tempsMisyAvion.Last();
                    for (int j = 0; j < listPConcerned[i].tempsMisyAvion.Count; j++)
                    {
                        System.Diagnostics.Debug.WriteLine("vol décalée pour le vol :" + this.id_Vol + "à la piste " + listPConcerned[i].id_piste + " - " + listPConcerned[i].tempsMisyAvion[j].debut_occupation + " - " + listPConcerned[i].tempsMisyAvion[j].fin_occupation);
                    }
                    double decallage = (farany.fin_occupation - this.dateProbableArrivee).TotalMinutes;
                    if (decallage < min) //Iny ndray ny min vaovao anle volpiste satria inferieur amle teo aloha ny attente
                    {
                        min = decallage;
                        this.id_piste = listPConcerned[i].id_piste;
                        Otemp = new Occupation(listPConcerned[i].id_piste, this.id_Vol, farany.fin_occupation, farany.fin_occupation.AddHours(listPConcerned[i].Degagement));
                        temp = i; //indice anle piste
                        this.decalage = min;
                    }
                }
            }
            listPConcerned[temp].tempsMisyAvion = new List<Occupation>();
            listPConcerned[temp].tempsMisyAvion.Add(Otemp);
        }

        public string id_piste { get; set; }

        public DateTime fin_utilisation { get; set; }

        public double duree_occupation { get; set; }

        public double diff { get; set; }

        
    }
}