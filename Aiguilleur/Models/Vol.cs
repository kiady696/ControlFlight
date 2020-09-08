using Aiguilleur.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;

namespace Aiguilleur.Models
{
    public class Vol
    {
        public Vol() { }
        public Vol(string id_Vol)
        {
            this.id_Vol = id_Vol ?? throw new ArgumentNullException(nameof(id_Vol));
        }

        public string id_Vol { get; set; }

       
        public string id_Aeroport_Depart { get; set; }

       
        public string id_Aeroport_Arrivee { get; set; }

       
        public string id_Avion { get; set; }

        
        public DateTime date_Depart { get; set; }

        
        public double duree { get; set; } //en heure


        public double? decalage { get; set; }

        public int? etat { get; set; }

        public Modele modele_Avion { get; set; } //extends Avion

        public string action { get; set; } //veut 'decoller' ou 'atterrir'

        public DateTime dateProbableArrivee { get; set; } //basically date_Depart + duree if it is a action='landing'

        public double besoin { get; set; }


        //Retourne une List<VolPiste> contenant le modele d'avion , le besoin et l'ordre selon dateProbable arrivee  
        public static List<VolPiste> getVolsOrdered(DBConnection dbc ,List<Vol> vols , List<Piste> pistesOfAirport)
        {

            //tsy mbola milahatra selon dateProbArr eto
            List<VolPiste> res = new List<VolPiste>();

            //get modele avion de ce vol
            foreach (Vol v in vols)
            {
                v.getModeleAvion();
            }


            //get besoin de cet avion : 
            //si vols[i].action = 'decoller' => vols[i].besoin = (vols[i].modele_Avion.longueur + vols[i].modele_Avion.besoin_Decollage)
            //si vols[i].action = 'atterir' => vols[i].besoin = (vols[i].modele_Avion.longueur + vols[i].modele_Avion.besoin_Atterrissage)
            System.Diagnostics.Debug.WriteLine(vols[0].action);
            foreach (Vol v in vols)
            {
                if (v.action == "Decoller")
                {
                    v.besoin = (v.modele_Avion.longueur_modele + v.modele_Avion.besoin_Decollage);
                    System.Diagnostics.Debug.WriteLine("Le besoin du vol "+v.id_Vol+" est "+v.besoin);
                }
                else if (v.action == "Atterir")
                {
                    v.besoin = (v.modele_Avion.longueur_modele + v.modele_Avion.besoin_Atterrissage);
                    System.Diagnostics.Debug.WriteLine("Le besoin du vol " + v.id_Vol + " est " + v.besoin);
                }
            }
            

                /*//Comparer pour chaque besoins des vols et pour chaque Pistes de l'aeroport si vols[i].besoin < aeroport.pistes[i].longueur
                //si le if est verifié , resultat.add(new VolPiste(id_Vol,num piste,....));
                System.Diagnostics.Debug.WriteLine(vols[1].besoin);
                foreach(Piste p in aeroport.pistes)
                {
                    System.Diagnostics.Debug.WriteLine(vols[0].id_Vol);
                    foreach (Vol v in vols)
                    {
                        System.Diagnostics.Debug.WriteLine(vols[0].id_Vol);
                        if (v.besoin < p.longueur)
                        {
                        System.Diagnostics.Debug.WriteLine("temps_degagement : " + p.Degagement);
                            res.Add(new VolPiste(v.id_Vol, p.id_piste,v.dateProbableArrivee,p.Degagement)); // add autant d'info possible
                        }
                    }

                    
                }*/
            
            //Casting to VolPiste without any piste linking for the moment and so no piste.Degagement still known
            foreach(Vol v in vols)
            {
                res.Add(new VolPiste(v.id_Vol, " ",v.besoin, v.dateProbableArrivee, 0));
            }

            //Eto vao alahatra selon dateProbArrivee
            res = res.OrderBy(x => x.dateProbableArrivee).ToList();

            return res;                 
        }

        ////get modele avion de ce vol
        public void getModeleAvion()
        {
            
                string sqlQuery = "SELECT * FROM AVION INNER JOIN MODELE ON AVION.ID_MODELE=MODELE.ID_MODELE WHERE ID_AVION = '"+this.id_Avion+"'";
                System.Diagnostics.Debug.WriteLine(sqlQuery);
                using (IDbConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\KIADY\Documents\S6\Tahina - projets S6\C#\Aiguilleur\Aiguilleur\App_Data\aiguilleur.mdf;Integrated Security=True"))
                {
                    db.Open();
                    this.modele_Avion = db.QuerySingle<Modele>(sqlQuery);
                    db.Close();
                }
            
            
        }


    }
}