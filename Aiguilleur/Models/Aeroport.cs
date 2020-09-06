using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Aiguilleur.Connection;
using Aiguilleur.Utils;
using Dapper;

namespace Aiguilleur.Models
{
    public class Aeroport
    {
        public string id_aeroport { get; set; }
        public string code_aeroport { get; set; }
        public string ville { get; set; }
        public string villeAeroport { get; set; }

        public List<Vol> vols; //tous les vols entrants/sortants de l'aeroport

        public List<Piste> pistes; //les pistes de l'aeroport

        public void getPistes(DBConnection dbc)
        {
            string sqlQuery = "SELECT * FROM Piste WHERE Id_Aeroport='"+this.id_aeroport+"'";
            System.Diagnostics.Debug.WriteLine(sqlQuery);
            using (SqlConnection connection = dbc.getCon())
            {
                this.pistes = connection.Query<Piste>(sqlQuery).ToList();
                System.Diagnostics.Debug.WriteLine("NAMERINA T DEGAG VE :"+pistes[0].Degagement);
            }
        }

        public Aeroport(string idAeroport)   
        {
            this.id_aeroport = idAeroport ?? throw new ArgumentNullException(nameof(idAeroport));
        }

        public Aeroport(string id_aeroport, string code_aeroport, string ville) : this(id_aeroport)
        {
            this.code_aeroport = code_aeroport ?? throw new ArgumentNullException(nameof(code_aeroport));
            this.ville = ville ?? throw new ArgumentNullException(nameof(ville));
            this.villeAeroport = ville + ' ' + code_aeroport;
        }

       

        //F° manova anle tableau des vols ho entre deux dates à cet Aeroport (précis)
        public void getVolAt(DateTime debut,DateTime fin)
        {
            //izay 'veut decoller' ny action-ny dia date_depart anaty debut-fin ny dateprob no averina
            //izay 'veut atterir' kosa dia calculer-na ny dateProbablearrive-ny ka izay anaty debut-fin ny dateprob no averina 
            for(int i = 0;i<this.vols.Count;i++) //vols efa voa getAction reto
            {
                if(this.vols[i].action == "Decoller")
                {
                    this.vols[i].dateProbableArrivee = this.vols[i].date_Depart;
                }else if(this.vols[i].action == "Atterir")
                {
                    this.vols[i].dateProbableArrivee = this.vols[i].date_Depart.AddHours(this.vols[i].duree);
                }
                //Alana daholo izay tsy entre debut sy fin ny dateprob-any
                else if (this.vols[i].dateProbableArrivee.CompareTo(debut) < 0 || this.vols[i].dateProbableArrivee.CompareTo(fin) > 0)
                {
                    this.vols.RemoveAt(i);
                }
            }
            
            
        }


        //F° mtrier anle vols hoe iza n atterissage,iza ny decollage ato amn'ito aeroport ito
        public void getAction()
        {
            foreach(Vol v in this.vols)
            {
                if(v.id_Aeroport_Arrivee == id_aeroport)
                {
                    v.action = "Atterir";
                }else if(v.id_Aeroport_Depart == id_aeroport)
                {
                    v.action = "Decoller";
                }
            }
        }

        public List<Vol> getVols()
        {
            return this.vols;
        }

        //F° mget ireo vols date_depart entre deux dates (a peu près)
        public void getAllFlightsAirport(DBConnection dbc,DateTime debut,DateTime fin)
        {
            DateTime refe = new DateTime(1999, 1, 1, 0, 0, 0);
            try
            {
                //raha tsy napiditra date mihitsy
                if (debut.CompareTo(refe) == 0 && fin.CompareTo(refe) == 0)
                {
                    //par defaut : ts les vols pdt trois jour
                    string sqlQuery = "SELECT * FROM VOL WHERE (Date_Depart BETWEEN DATEADD(day, -1, GETDATE()) AND DATEADD(day, +1, GETDATE())) AND (Id_Aeroport_Depart = '" + this.id_aeroport + "' OR Id_Aeroport_Arrivee = '" + this.id_aeroport + "') ";
                    System.Diagnostics.Debug.WriteLine(sqlQuery);
                    using (SqlConnection connection = dbc.getCon())
                    {
                        this.vols = connection.Query<Vol>(sqlQuery).ToList();
                    }

                }

                else if (debut.CompareTo(refe) == 0)
                {
                    debut = Utilitaires.getToday();
                    string sqlQuery = "SELECT * FROM VOL WHERE (Date_Depart BETWEEN '" + debut.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND '" + fin.ToString("yyyy-MM-dd HH:mm:ss.fff") + "') AND (Id_Aeroport_Depart = '" + this.id_aeroport + "' OR Id_Aeroport_Arrivee = '" + this.id_aeroport + "') ";
                    System.Diagnostics.Debug.WriteLine(sqlQuery);
                    using (SqlConnection connection = dbc.getCon())
                    {
                        this.vols = connection.Query<Vol>(sqlQuery).ToList();
                    }
                }
                else if (fin.CompareTo(refe) == 0)
                {
                    fin = Utilitaires.getToday();
                    string sqlQuery = "SELECT * FROM VOL WHERE (Date_Depart BETWEEN '" + debut.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND '" + fin.ToString("yyyy-MM-dd HH:mm:ss.fff") + "') AND (Id_Aeroport_Depart = '" + this.id_aeroport + "' OR Id_Aeroport_Arrivee = '" + this.id_aeroport + "') ";
                    System.Diagnostics.Debug.WriteLine(sqlQuery);
                    using (SqlConnection connection = dbc.getCon())
                    {
                        this.vols = connection.Query<Vol>(sqlQuery).ToList();
                    }
                }
                else if (debut.CompareTo(fin) > 0 || fin.CompareTo(debut) < 0)
                {
                    throw new Exception("Erreur d\'intervalle de temps! Re-saisir vos entrées de date");
                }
                else
                {
                    //tsotra
                    string sqlQuery = "SELECT * FROM VOL WHERE (Date_Depart BETWEEN '" + debut.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND '" + fin.ToString("yyyy-MM-dd HH:mm:ss.fff") + "') AND (Id_Aeroport_Depart = '" + this.id_aeroport + "' OR Id_Aeroport_Arrivee = '" + this.id_aeroport + "') ";
                    System.Diagnostics.Debug.WriteLine(sqlQuery);
                    using (SqlConnection connection = dbc.getCon())
                    {
                        this.vols = connection.Query<Vol>(sqlQuery).ToList();
                    }
                }

            }
            catch (Exception exc)
            {
                throw exc;
            }
            
            
        }

        public static List<Aeroport> getAirports(DBConnection dbc)
        {
            string query = "SELECT * FROM AEROPORT ";
            List<Aeroport> res = null;
            using (SqlConnection connection = dbc.getCon())
            {
                res = connection.Query<Aeroport>(query).ToList();
            }
            return res;
        }

    }
}